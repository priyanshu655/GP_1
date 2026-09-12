using GP_1.Forms;

namespace GP_1;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        // Seed.Initialize();
        Application.Run(new FrmTransaction());
    }    
}