using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GWVACB_HFT_2023241.WPFClient
{
     public class MenuWindowViewModel 
    {
        public ICommand OpenAuthorsCommand { get; set; }
        public ICommand OpenQuotesCommand { get; set; }
        public ICommand OpenCommentsCommand { get; set; }

        public MenuWindowViewModel()
        {
            OpenAuthorsCommand = new RelayCommand(() =>
            {
                AuthorWindow autorWindow = new AuthorWindow();
                autorWindow.Show();
            });

            OpenQuotesCommand = new RelayCommand(() =>
            {
                QuoteWindow quoteWindow = new QuoteWindow();
                quoteWindow.Show();
            });

            OpenCommentsCommand = new RelayCommand(() =>
            {
                CommentWindow commentWindow = new CommentWindow();
                commentWindow.Show();
            });
        }
    }
}
