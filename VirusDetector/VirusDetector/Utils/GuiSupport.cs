
namespace VirusDetector.Utils
{
    class GuiSupport
    {
        readonly FormMain _gui;
        public GuiSupport(FormMain gui)
        {
            _gui = gui;
        }

        public void UpdateProgressBar()
        {
            _gui.UpdateProgressBarCallBack();
        }

        internal void InitProgressBar()
        {
            _gui.InitProgressBarCallBack();
        }

        internal void UpdateVirusFragment()
        {
            _gui.UpdateVirusFragmentCallBack();
        }
    }
}
