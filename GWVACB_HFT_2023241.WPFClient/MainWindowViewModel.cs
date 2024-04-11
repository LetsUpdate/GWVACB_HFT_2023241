﻿using GWVACB_HFT_2023241.Models;
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
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Author> Authors
        {
            get; set;
        }
        private Author _selectedAuthor;
        public Author SelectedAuthor
        {
            get { return _selectedAuthor; }
            set
            {
                if (value != null) { 

                _selectedAuthor = new Author()
                {
                    Id = value.Id,
                    Name = value.Name,
                    Age = value.Age,
                    Country = value.Country
                };
                OnPropertyChanged();

                (DeleteAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
            }
            }
        }
        public ICommand CreateAuthorCommand { get; set; }
        public ICommand UpdateAuthorCommand { get; set; }
        public ICommand DeleteAuthorCommand { get; set; }

        public MainWindowViewModel()
        {
            Authors = new RestCollection<Author>("http://localhost:5005/", "Author","hub");

            CreateAuthorCommand = new RelayCommand(() =>
            {

                Authors.Add(new Author() { Name = SelectedAuthor.Name, Age = SelectedAuthor.Age, Country = SelectedAuthor.Country });
            });
            DeleteAuthorCommand = new RelayCommand(() =>
            {
                Authors.Delete(SelectedAuthor.Id);
            }, () => { return SelectedAuthor != null; });

            UpdateAuthorCommand = new RelayCommand(() =>
            {
                Authors.Update(SelectedAuthor);
            }, () => { return SelectedAuthor != null; });
            _selectedAuthor=new Author();
        }
    }
}
