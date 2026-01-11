using Plugin.Maui.Audio;
namespace Dziekanowka.Mechanizm
{
    public class Dzwieki
    {
        public static Dzwieki? Dzwiek { get; set; }
        private readonly IAudioManager audioManager;
        private IAudioPlayer? tloPlayer;
        private string? aktualnieGraneTlo;
        private int aktualnieGrajaceDzwieki = 0;
        private readonly object blokada = new object();
        public Dzwieki(IAudioManager audioManager)
        {
            this.audioManager = audioManager;
        }
        public async Task GraTlo(string sciezka)
        {
            if (aktualnieGraneTlo == sciezka && tloPlayer != null && tloPlayer.IsPlaying) return;
            tloPlayer?.Stop();
            tloPlayer?.Dispose();
            var stream = await FileSystem.OpenAppPackageFileAsync(sciezka);
            tloPlayer = audioManager.CreatePlayer(stream);
            tloPlayer.Loop = true;
            tloPlayer.Play();
            aktualnieGraneTlo = sciezka;
        }
        public async Task GraDzwiek(string sciezka)
        {
            lock (blokada)
            {
                if (aktualnieGrajaceDzwieki >= 3) return;
                aktualnieGrajaceDzwieki++;
            }
            IAudioPlayer? player = null;
            try
            {
                var stream = await FileSystem.OpenAppPackageFileAsync(sciezka);
                player = audioManager.CreatePlayer(stream);
                var tcs = new TaskCompletionSource<bool>();
                player.PlaybackEnded += (s, e) => { tcs.TrySetResult(true); };
                player.Play();
                await tcs.Task;
            }
            catch { }
            finally
            {
                player?.Dispose();
                lock (blokada)
                {
                    aktualnieGrajaceDzwieki--;
                }
            }
        }
    }
}