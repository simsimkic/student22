using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Controller;
using Model.Doctor;
using Model.Manager;
using Model.Users;
using ProjekatKlinika.Controller;
using ProjekatKlinika.Repository;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using Repository;
using Service;

namespace projekatHCI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string MANAGERS_FILE = "..\\..\\..\\..\\projekat\\Resources\\managers.json";
        private const string SECRETARIES_FILE = "..\\..\\..\\..\\projekat\\Resources\\secretaries.json";
        private const string DOCTORS_FILE = "..\\..\\..\\..\\projekat\\Resources\\doctors.json";
        private const string DRUGS_FILE = "..\\..\\..\\..\\projekat\\Resources\\drugs.json";
        private const string ROOMS_FILE = "..\\..\\..\\..\\projekat\\Resources\\rooms.json";



        public ManagerController managerController;
        public SecretaryController secretaryController;
        public DoctorController doctorController;
        public DrugController drugController;
        public RoomController roomController;

        public App()
        {
            ManagerRepository managerRepository = new ManagerRepository(
                new JsonStream<Manager>(MANAGERS_FILE), new LongSequencer());

            SecretaryRepository secretaryRepository = new SecretaryRepository(
                new JsonStream<Secretary>(SECRETARIES_FILE), new LongSequencer());

            DoctorRepository doctorRepository = new DoctorRepository(
                new JsonStream<Doctor>(DOCTORS_FILE), new LongSequencer());

            DrugRepository drugRepository = new DrugRepository(
             new JsonStream<Drug>(DRUGS_FILE), new LongSequencer());

            RoomRepository roomRepository = new RoomRepository(
             new JsonStream<Room>(ROOMS_FILE), new LongSequencer());

            ManagerService managerService = new ManagerService(managerRepository);
            SecretaryService secretaryService = new SecretaryService(secretaryRepository);
            DoctorService doctorService = new DoctorService(doctorRepository);
            DrugService drugService = new DrugService(drugRepository);
            RoomService roomService = new RoomService(roomRepository);

            managerController = new ManagerController(managerService);
            secretaryController = new SecretaryController(secretaryService);
            doctorController = new DoctorController(doctorService);
            drugController = new DrugController(drugService);
            roomController = new RoomController(roomService);

            Manager manager = new Manager();
            manager.email = "emina@gmail.com";
            manager.password = "pera";
           

            Secretary secretary = new Secretary();
            secretary.name = "Nemanja";
            secretary.surname = "Mikic";
            secretary.email = "n@gmail.com";
            secretary.jmbg = "123456759";

            Doctor doctor = new Doctor();
            doctor.name = "Tamara";
            doctor.surname = "Rankovic";
            doctor.jmbg = "225602";
            doctor.email = "t@g.com";
          
           
           
        }

    }
}
