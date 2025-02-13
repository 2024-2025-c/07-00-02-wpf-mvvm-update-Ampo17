using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using System.Threading.Tasks;
using System;
using Kreta.Shared.Models.Entites;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using Kreta.Desktop.ViewModels.Base;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Drawing.Text;

namespace Kreta.Desktop.ViewModels.SchoolSubjects
{
    public partial class SubjectsManagmentViewModel : BaseViewModel
    {
        private readonly ISubjectHttpService _httpService;

        [ObservableProperty]
        private ObservableCollection<Subject> _subjects= new ObservableCollection<Subject>();

        // 2.b Adatstruktúra a kiválasztott tantárgynak
        [ObservableProperty]
        private Subject _selectsubject= new Subject();

        public SubjectsManagmentViewModel()
        {
            
        }

        //1.b Konstruktorban injektáljuk a ISubjectHttpService
        public SubjectsManagmentViewModel(ISubjectHttpService? httpService)
        {
            _httpService=httpService ?? throw new ArgumentNullException(nameof(httpService));
        }

        // 1. feladat: tantárgyak adatainak lekérése a backendről (vizsgaremek)
        // 1.a Adatok menüpont kiválasztására jelenjenek meg: InitializeAsync    }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            await UpdateViewAsync();   
        }

        [RelayCommand]
        private void DoNewSubject()
        {
            ClearForm();
        }

        [RelayCommand]
        private async Task DoDelete(Subject subject)
        {
            if(subject is not null)
            {
                await _httpService.DeleteAsync(subject.Id);
                ClearForm();
                await UpdateViewAsync();
            }
        }

        // 1.c Adatok bekérése a backendről
        private async Task UpdateViewAsync()
        {
            //1.d HttpServic-en keresztül backend hívás
            List<Subject> subjects = await _httpService.GetAllAsync();
            //2.a A megérkezett adatokkal újra létrehozzuk a Subjects ObservableCollection
            Subjects = new ObservableCollection<Subject>(subjects);

          
        } 
        //felkészülés a dolgozatra
        private void ClearForm()
        {
            Selectsubject = new Subject();
            OnPropertyChanged(nameof(Selectsubject));
        }
    }
}
