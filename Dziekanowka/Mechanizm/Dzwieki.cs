using Plugin.Maui.Audio;
namespace Dziekanowka.Mechanizm
{
    public class Dzwieki
    {
        private readonly IAudioManager audioManager;
        private IAudioPlayer? tloPlayer;
        private IAudioPlayer? dzwiekPlayer;
        public Dzwieki(IAudioManager audioManager)
        {
            this.audioManager = audioManager;
        }
        public async Task GraTlo(string sciezka)
        {
            tloPlayer?.Stop();
            tloPlayer?.Dispose();
            var stream = await FileSystem.OpenAppPackageFileAsync(sciezka);
            tloPlayer = audioManager.CreatePlayer(stream);
            tloPlayer.Loop = true;
            tloPlayer.Play();
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