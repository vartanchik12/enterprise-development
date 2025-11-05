using Hospital.Domain;
namespace Hospital.Tests;

public class HospitalFixture
{
    public static List<Specialization> Specializations { get; } = new List<Specialization>
    {
        new Specialization { ID = 1, Name = "Кардиолог" },
        new Specialization { ID = 2, Name = "Невролог" },
        new Specialization { ID = 3, Name = "Педиатр" },
        new Specialization { ID = 4, Name = "Онколог" },
        new Specialization { ID = 5, Name = "Дерматолог" },
        new Specialization { ID = 6, Name = "Психиатр" },
        new Specialization { ID = 7, Name = "Хирург" },
        new Specialization { ID = 8, Name = "Ортопед" },
        new Specialization { ID = 9, Name = "Офтальмолог" },
        new Specialization { ID = 10, Name = "Гинеколог" }
    };

    public List<Doctor> Doctors { get; } = new List<Doctor>
    {
        new Doctor { ID = 1, Passport = "4501 123456", FullName = "Иванов Сергей Петрович", BirthYear = 1975, Specialization = Specializations[0], WorkExperience = 15 },
        new Doctor { ID = 2, Passport = "4502 234567", FullName = "Петрова Анна Владимировна", BirthYear = 1980, Specialization = Specializations[1], WorkExperience = 12 },
        new Doctor { ID = 3, Passport = "4503 345678", FullName = "Сидоров Алексей Иванович", BirthYear = 1982, Specialization = Specializations[2], WorkExperience = 10 },
        new Doctor { ID = 4, Passport = "4504 456789", FullName = "Кузнецова Мария Сергеевна", BirthYear = 1978, Specialization = Specializations[3], WorkExperience = 14 },
        new Doctor { ID = 5, Passport = "4505 567890", FullName = "Васильев Дмитрий Николаевич", BirthYear = 1985, Specialization = Specializations[4], WorkExperience = 8 },
        new Doctor { ID = 6, Passport = "4506 678901", FullName = "Николаева Ольга Борисовна", BirthYear = 1970, Specialization = Specializations[5], WorkExperience = 20 },
        new Doctor { ID = 7, Passport = "4507 789012", FullName = "Федоров Игорь Васильевич", BirthYear = 1983, Specialization = Specializations[6], WorkExperience = 9 },
        new Doctor { ID = 8, Passport = "4508 890123", FullName = "Алексеева Татьяна Дмитриевна", BirthYear = 1979, Specialization = Specializations[7], WorkExperience = 13 },
        new Doctor { ID = 9, Passport = "4509 901234", FullName = "Павлов Андрей Викторович", BirthYear = 1981, Specialization = Specializations[8], WorkExperience = 11 },
        new Doctor { ID = 10, Passport = "4510 012345", FullName = "Семенова Елена Александровна", BirthYear = 1976, Specialization = Specializations[9], WorkExperience = 16 }
    };

    public List<Patient> Patients { get; } = new List<Patient>
    {
        new Patient { ID = 1, Passport = "4501 555001", FullName = "Смирнов Александр Игоревич", Sex = Sex.Male, BirthDate = new DateTime(1990, 5, 15), Address = "ул. Ленина, д. 10, кв. 25", BloodType = BloodType.II, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-11-11" },
        new Patient { ID = 2, Passport = "4502 555002", FullName = "Ковалева Ирина Сергеевна", Sex = Sex.Female, BirthDate = new DateTime(1985, 8, 22), Address = "ул. Мира, д. 5, кв. 14", BloodType = BloodType.I, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-22-22" },
        new Patient { ID = 3, Passport = "4503 555003", FullName = "Морозов Петр Васильевич", Sex = Sex.Male, BirthDate = new DateTime(2004, 3, 10), Address = "пр. Победы, д. 25, кв. 7", BloodType = BloodType.III, RHFactor = RHFactor.Negative, PhoneNumber = "+7 (915) 100-33-33" },
        new Patient { ID = 4, Passport = "4504 555004", FullName = "Волкова Наталья Дмитриевна", Sex = Sex.Female, BirthDate = new DateTime(1995, 11, 30), Address = "ул. Садовая, д. 15, кв. 32", BloodType = BloodType.IV, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-44-44" },
        new Patient { ID = 5, Passport = "4505 555005", FullName = "Белов Андрей Павлович", Sex = Sex.Male, BirthDate = new DateTime(1982, 7, 5), Address = "ул. Центральная, д. 8, кв. 19", BloodType = BloodType.II, RHFactor = RHFactor.Negative, PhoneNumber = "+7 (915) 100-55-55" },
        new Patient { ID = 6, Passport = "4506 555006", FullName = "Жукова Светлана Олеговна", Sex = Sex.Female, BirthDate = new DateTime(1973, 12, 18), Address = "ул. Лесная, д. 3, кв. 41", BloodType = BloodType.I, RHFactor = RHFactor.Negative, PhoneNumber = "+7 (915) 100-66-66" },
        new Patient { ID = 7, Passport = "4507 555007", FullName = "Тихонов Михаил Юрьевич", Sex = Sex.Male, BirthDate = new DateTime(1992, 2, 28), Address = "пр. Строителей, д. 12, кв. 8", BloodType = BloodType.III, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-77-77" },
        new Patient { ID = 8, Passport = "4508 555008", FullName = "Орлова Дарья Викторовна", Sex = Sex.Female, BirthDate = new DateTime(1988, 9, 9), Address = "ул. Молодежная, д. 7, кв. 23", BloodType = BloodType.II, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-88-88" },
        new Patient { ID = 9, Passport = "4509 555009", FullName = "Григорьев Виктор Иванович", Sex = Sex.Male, BirthDate = new DateTime(1975, 6, 14), Address = "ул. Речная, д. 18, кв. 15", BloodType = BloodType.IV, RHFactor = RHFactor.Negative, PhoneNumber = "+7 (915) 100-99-99" },
        new Patient { ID = 10, Passport = "4510 555010", FullName = "Соколова Марина Анатольевна", Sex = Sex.Female, BirthDate = new DateTime(1998, 4, 3), Address = "ул. Школьная, д. 9, кв. 11", BloodType = BloodType.I, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-00-00" },
        new Patient { ID = 11, Passport = "4511 555011", FullName = "Новиков Сергей Петрович", Sex = Sex.Male, BirthDate = new DateTime(1980, 1, 15), Address = "ул. Солнечная, д. 11, кв. 5", BloodType = BloodType.II, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 111-11-11" }, // 45 лет
        new Patient { ID = 12, Passport = "4512 555012", FullName = "Павлова Елена Владимировна", Sex = Sex.Female, BirthDate = new DateTime(1983, 12, 10), Address = "ул. Весенняя, д. 20, кв. 33", BloodType = BloodType.III, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 122-22-22" } // 42 года
    };

    public List<Appointment> Appointments { get; } = new List<Appointment>
    {
        new Appointment { ID = 1, AppointmentTime = new DateTime(2025, 8, 15), RoomNumber = 101, IsFollow = false, PatientId = 1, DoctorId = 1 },
        new Appointment { ID = 2, AppointmentTime = new DateTime(2025, 9, 10), RoomNumber = 205, IsFollow = true, PatientId = 2, DoctorId = 3 },
        new Appointment { ID = 3, AppointmentTime = new DateTime(2025, 10, 16), RoomNumber = 302, IsFollow = false, PatientId = 3, DoctorId = 5 },
        new Appointment { ID = 4, AppointmentTime = new DateTime(2025, 10, 16), RoomNumber = 104, IsFollow = true, PatientId = 4, DoctorId = 7 },
        new Appointment { ID = 5, AppointmentTime = new DateTime(2025, 10, 17), RoomNumber = 208, IsFollow = false, PatientId = 5, DoctorId = 2 },
        new Appointment { ID = 6, AppointmentTime = new DateTime(2025, 10, 17), RoomNumber = 305, IsFollow = true, PatientId = 6, DoctorId = 9 },
        new Appointment { ID = 7, AppointmentTime = new DateTime(2025, 10, 18), RoomNumber = 112, IsFollow = false, PatientId = 7, DoctorId = 4 },
        new Appointment { ID = 8, AppointmentTime = new DateTime(2025, 10, 18), RoomNumber = 214, IsFollow = true, PatientId = 8, DoctorId = 6 },
        new Appointment { ID = 9, AppointmentTime = new DateTime(2025, 9, 19), RoomNumber = 309, IsFollow = false, PatientId = 9, DoctorId = 8 },
        new Appointment { ID = 10, AppointmentTime = new DateTime(2025, 10, 19), RoomNumber = 117, IsFollow = true, PatientId = 10, DoctorId = 10 },
        new Appointment { ID = 11, AppointmentTime = new DateTime(2025, 10, 15), RoomNumber = 104, IsFollow = false, PatientId = 3, DoctorId = 1 },
        new Appointment { ID = 12, AppointmentTime = new DateTime(2025, 10, 20), RoomNumber = 201, IsFollow = false, PatientId = 11, DoctorId = 2 },
        new Appointment { ID = 13, AppointmentTime = new DateTime(2025, 10, 21), RoomNumber = 202, IsFollow = true, PatientId = 11, DoctorId = 4 },
        new Appointment { ID = 14, AppointmentTime = new DateTime(2025, 10, 22), RoomNumber = 203, IsFollow = false, PatientId = 11, DoctorId = 6 },
    
        new Appointment { ID = 15, AppointmentTime = new DateTime(2025, 10, 23), RoomNumber = 204, IsFollow = false, PatientId = 12, DoctorId = 3 },
        new Appointment { ID = 16, AppointmentTime = new DateTime(2025, 10, 24), RoomNumber = 205, IsFollow = true, PatientId = 12, DoctorId = 7 },

        new Appointment { ID = 17, AppointmentTime = new DateTime(2025, 10, 15), RoomNumber = 101, IsFollow = false, PatientId = 1, DoctorId = 1 },
        new Appointment { ID = 18, AppointmentTime = new DateTime(2025, 10, 20), RoomNumber = 101, IsFollow = true, PatientId = 2, DoctorId = 3 }
    };
}

