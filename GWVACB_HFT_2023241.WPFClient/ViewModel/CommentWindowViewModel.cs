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
    public class CommentWindowViewModel : ObservableRecipient
    {

        public RestCollection<Comment> Comments
        {
            get; set;
        }
        private Comment _selectedComment;
        public Comment SelectedComment
        {
            get { return _selectedComment; }
            set
            {
                if (value != null)
                {

                    //Create deep copy
                    _selectedComment = new Comment()
                    {
                        Id = value.Id,
                        Content = value.Content,
                        QuoteId = value.QuoteId
                                
                    };
                    OnPropertyChanged();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    (DeleteCommentCommand as RelayCommand).NotifyCanExecuteChanged();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    (UpdateCommentCommand as RelayCommand).NotifyCanExecuteChanged();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
            }
        }
        public ICommand CreateCommentCommand { get; set; }
        public ICommand UpdateCommentCommand { get; set; }
        public ICommand DeleteCommentCommand { get; set; }

        public CommentWindowViewModel()
        {
            Comments = new RestCollection<Comment>("http://localhost:5005/", "Comment", "hub");

            CreateCommentCommand = new RelayCommand(() =>
            {

                Comments.Add(new Comment() { Content = SelectedComment.Content, QuoteId = SelectedComment.QuoteId });
            });
            DeleteCommentCommand = new RelayCommand(() =>
            {
                Comments.Delete(SelectedComment.Id);
            }, () => { return SelectedComment != null; });

            UpdateCommentCommand = new RelayCommand(() =>
            {
                Comments.Update(SelectedComment);
            }, () => { return SelectedComment != null; });
            _selectedComment = new Comment();
        }
    }
}
