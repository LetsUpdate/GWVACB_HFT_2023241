using GWVACB_HFT_2023241.Models;
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
    public class QuoteWindowViewModel : ObservableRecipient
    {

        public RestCollection<Quote> Quotes
        {
            get; set;
        }
        private Quote _selectedQuote;
        public Quote SelectedQuote
        {
            get { return _selectedQuote; }
            set
            {
                if (value != null)
                {

                    //Create deep copy
                    _selectedQuote = new Quote()
                    {
                        Id = value.Id,
                        Content = value.Content,
                        Title = value.Title,
                        AuthorId = value.AuthorId
                                
                    };  

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    (DeleteQuoteCommand as RelayCommand).NotifyCanExecuteChanged();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    (UpdateQuoteCommand as RelayCommand).NotifyCanExecuteChanged();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
            }
        }
        public ICommand CreateQuoteCommand { get; set; }
        public ICommand UpdateQuoteCommand { get; set; }
        public ICommand DeleteQuoteCommand { get; set; }

        public QuoteWindowViewModel()
        {
            Quotes = new RestCollection<Quote>("http://localhost:5005/", "Quote", "hub");

            CreateQuoteCommand = new RelayCommand(() =>
            {

                Quotes.Add(new Quote() {Id = SelectedQuote.Id, Content = SelectedQuote.Content, Title = SelectedQuote.Title, AuthorId = SelectedQuote.AuthorId });
            });
            DeleteQuoteCommand = new RelayCommand(() =>
            {
                Quotes.Delete(SelectedQuote.Id);
            }, () => { return SelectedQuote != null; });

            UpdateQuoteCommand = new RelayCommand(() =>
            {
                Quotes.Update(SelectedQuote);
            }, () => { return SelectedQuote != null; });
            _selectedQuote = new Quote();
        }
    }
}
