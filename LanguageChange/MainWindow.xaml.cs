using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace LanguageChange
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        static bool chkLanguage;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HamburgerMenuControl_ItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs args)
        {
            HamburgerMenuGlyphItem menuItem = (HamburgerMenuGlyphItem)args.InvokedItem;
            string targetView = menuItem.Tag.ToString();
            switch (targetView)
            {
                case "LanguageChange":
                    if (chkLanguage)
                    {
                        LoadLanguageFile("Language/zh-TW.xaml");
                        chkLanguage = !chkLanguage;
                    }
                    else
                    {
                        LoadLanguageFile("Language/en-US.xaml");
                        chkLanguage = !chkLanguage;
                    }

                    break;
            }
        }

        void LoadLanguageFile(string languagefileName)
        {
            var resources = Application.Current.Resources;

            resources.BeginInit();
            var newRD = new ResourceDictionary()
            {
                Source = new Uri(languagefileName, UriKind.RelativeOrAbsolute)
            };
            resources.MergedDictionaries.RemoveAt(resources.MergedDictionaries.Count - 1);
            resources.MergedDictionaries.Add(newRD);
            resources.EndInit();

            foreach (var item in ((HamburgerMenuItemCollection)this.HamburgerMenuControl.ItemsSource).OfType<HamburgerMenuGlyphItem>())
            {
                item.InvalidateProperty(HamburgerMenuGlyphItem.LabelProperty);
            }
            foreach (var item in ((HamburgerMenuItemCollection)this.HamburgerMenuControl.OptionsItemsSource).OfType<HamburgerMenuGlyphItem>())
            {
                item.InvalidateProperty(HamburgerMenuGlyphItem.LabelProperty);
            }
        }
    }
}
