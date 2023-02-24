using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProjekatKlinika.Controller;
using ProjekatKlinika.Repository;
using ProjekatKlinika.Repository.Sequencer;
using ProjekatKlinika.Repository.JSON.Stream;
using Service;
using ProjekatKlinika.Service;
using Controller;
using Repository;
using Model.Manager;

namespace lekar_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ARTICLES_FILE = "..\\..\\..\\..\\projekat\\Resources\\articles.json";
        private const string ARTICLE_CATEGORIES_FILE = "..\\..\\..\\..\\projekat\\Resources\\articlecategories.json";
        private const string DOCTORS_FILE = "..\\..\\..\\..\\projekat\\Resources\\doctors.json";
        private const string PATIENTS_FILE = "..\\..\\..\\..\\projekat\\Resources\\patients.json";
        private const string DRUGS_FILE = "..\\..\\..\\..\\projekat\\Resources\\drugs.json";
        private const string MANAGERS_FILE = "..\\..\\..\\..\\projekat\\Resources\\managers.json";
        public ArticleController articleController;
        public ArticleCategoryController articleCategoryController;
        public DoctorController doctorController;
        public PatientController patientController;
        public DrugController drugController;
        public ManagerController managerController;
        public App()
        {
            ArticleRepository articleRepository = new ArticleRepository(
                new JsonStream<Article>(ARTICLES_FILE),
                new LongSequencer());
            ArticleCategoryRepository articleCategoryRepository = new ArticleCategoryRepository(
                new JsonStream<ArticleCategory>(ARTICLE_CATEGORIES_FILE),
                new LongSequencer());
            DoctorRepository doctorRepository = new DoctorRepository(
                new JsonStream<Doctor>(DOCTORS_FILE),
                new LongSequencer());
            PatientRepository patientRepository = new PatientRepository(
                new JsonStream<Patient>(PATIENTS_FILE),
                new LongSequencer());
            DrugRepository drugRepository = new DrugRepository(
                new JsonStream<Drug>(DRUGS_FILE),
                new LongSequencer());
            ManagerRepository managerRepository = new ManagerRepository(
                new JsonStream<Manager>(MANAGERS_FILE),
                new LongSequencer());

            ArticleService articleService = new ArticleService(articleRepository);
            ArticleCategoryService articleCategoryService = new ArticleCategoryService(articleCategoryRepository);
            DoctorService doctorService = new DoctorService(doctorRepository);
            PatientService patientService = new PatientService(patientRepository);
            DrugService drugService = new DrugService(drugRepository);
            ManagerService managerService = new ManagerService(managerRepository);

            articleController = new ArticleController(articleService);
            articleCategoryController = new ArticleCategoryController(articleCategoryService);
            doctorController = new DoctorController(doctorService);
            patientController = new PatientController(patientService);
            drugController = new DrugController(drugService);
            managerController = new ManagerController(managerService);

            Manager m = new Manager();
            m.email = "emina@gmail.com";
            m.password = "mika";
            managerController.Create(m);
        }
    }
}

