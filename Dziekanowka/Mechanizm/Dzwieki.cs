using Plugin.Maui.Audio;
namespace Dziekanowka.Mechanizm
{
    public class Dzwieki
    {
        public static Dzwieki? Dzwiek { get; set; }
        private readonly IAudioManager audioManager;
        private IAudioPlayer? tloPlayer;
        private IAudioPlayer? dzwiekPlayer;
        private string? aktualnieGraneTlo;
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
            dzwiekPlayer?.Stop();
            dzwiekPlayer?.Dispose();
            var stream = await FileSystem.OpenAppPackageFileAsync(sciezka);
            dzwiekPlayer = audioManager.CreatePlayer(stream);
            dzwiekPlayer.Play();
        }
    }
}