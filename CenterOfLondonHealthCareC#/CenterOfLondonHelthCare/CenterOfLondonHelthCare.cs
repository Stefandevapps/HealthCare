using System;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace London_HealthCare_Application
{
    class GetRoomsToHealthCare
    {
        private const int per_DayValue = 1000;

        private static int totalRoomNo = 20;
        private static string[] timeSessionSlot = new string[3];
        private static string pettren = "{0,-29}{1,-19}{2,-59}";


        static MySqlConnection my_connection;

        public GetRoomsToHealthCare()
        {
            timeSessionSlot[0] = "Time: 7:00 AM – 12:00 NOON";
            timeSessionSlot[1] = "Time: 12:00 NOON – 5:00 PM";
            timeSessionSlot[2] = "Time: 5:00 PM – 10:00 PM";
        }

        public static void Main(string[] args)
        {
            my_connection = MySqlDBConnection;
            new GetRoomsToHealthCare();

            Console.WriteLine("\n\n\t\t\t\t\t\tWelcome to LONDON HEALTH CARE APPLICATON\n\n");

            while (true)
            {
                string meneuCard = "\n\t1. Registration Of A Specialist.\t" +
                "\t2. Room Booking.\t\t" +
                "\t3. Appointment Booking.\t\t" +
                "\t4. Earning Amount\n\n\t\t" +
                "\t\t\t\t\t\t\t\t5. Exit\n\n" +
                "\tEnter Your Selection ";

                int menuOption = 0;
                Console.WriteLine(meneuCard);
                try
                {
                    menuOption = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception ee)
                {
                    Console.WriteLine("Invalid Choice");
                }

                switch (menuOption)
                {
                    case 1:
                        registration_of_specialist();
                        break;
                    case 2:
                        Book_room_for_the_specialist();
                        break;
                    case 3:
                        Book_appointment_for_the_patient();
                        break;
                    case 4:
                        Console.WriteLine(Appointment_Earnings_Calculate());
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
            
            
        }

        public static MySqlConnection MySqlDBConnection
        {
            get
            {
                string DataConnection = "datasource = localhost;  username = root; password =; database = healthcaredb";

                MySqlConnection conn = new MySqlConnection(DataConnection);
                return conn;
            }
        }

        public static void registration_of_specialist()
        {
            string specialist_full_name, specialist_marriage_status, specialist_gender_detail, specialist_D_O_B, specialist_permanant_address,
                specialst_mobile_number, specialist_emergency_contact_number, specialist_higher_education_degree, certificate_of_training, specialist_authorize_membership,
                valid_specialist_proof_two_documents, photo_id_specialist, valid_crb_specialist, first_person_reference, second_person_reference, third_person_reference;

            Console.WriteLine("Full Name of the specialist: ");
            specialist_full_name = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Merital status of the specialist: ");
            specialist_marriage_status = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Gender of the specialist : ");
            specialist_gender_detail = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("DOB of the specialist: ");
            specialist_D_O_B = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Contact address of the specialist : ");
            specialist_permanant_address = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Contact number of the specialist: ");
            specialst_mobile_number = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Emergency contact number of the specialist : ");
            specialist_emergency_contact_number = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Highest educations And specialization of the specialist: ");
            specialist_higher_education_degree = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Training certificates of the specialist: ");
            certificate_of_training = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Professional membership of the specialist: ");
            specialist_authorize_membership = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Two valid documents for address proof of the specialist: ");
            valid_specialist_proof_two_documents = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Photograph of the specialist (y/n): ");
            photo_id_specialist = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("valid CRB of the specialist: ");
            valid_crb_specialist = Console.ReadLine();
            Console.WriteLine("\n");

            first_person_reference = ReferencesDetails_adding("First");

            second_person_reference = ReferencesDetails_adding("Second");
            while (first_person_reference.Equals(second_person_reference))
            {
                Console.WriteLine("Enter different refrence.");
                second_person_reference = ReferencesDetails_adding("Second");
            }
            third_person_reference = ReferencesDetails_adding("Third");
            while (third_person_reference.Equals(second_person_reference) || third_person_reference.Equals(first_person_reference))
            {
                Console.WriteLine("Enter different refrence.");
                third_person_reference = ReferencesDetails_adding("Third");
            }



            string SQL_String = "INSERT INTO register_specialist(specialist_name, MeritalStatus_specialist," +
                " gender, DOB, specialist_contact_address, specialist_contact_number, emergency_contact_number," +
                " specialist_higher_education, specialist_training_certificate, specialist_membership, specialist_two_id_documents, " +
                "specialist_photo_id, specialist_crb, specialist_first_person_reference_name, specialist_second_person_reference_name, specialist_third_person_reference_name) " +
                "VALUES ('" + specialist_full_name + "','" + specialist_marriage_status + "'," +
                "'" + specialist_gender_detail + "','" + specialist_D_O_B + "','" + specialist_permanant_address + "','" + specialst_mobile_number + "'," +
                "'" + specialist_emergency_contact_number + "','" + specialist_higher_education_degree + "'," +
                "'" + certificate_of_training + "','" + specialist_authorize_membership + "','" + valid_specialist_proof_two_documents + "','" + photo_id_specialist + "'," +
                "'" + valid_crb_specialist + "','" + first_person_reference + "'," +
                "'" + second_person_reference + "','" + third_person_reference + "')";

            MySqlCommand sql_comm2 = new MySqlCommand(SQL_String, my_connection);
            MySqlDataReader data_read2;

            my_connection.Open();
            data_read2 = sql_comm2.ExecuteReader();  
                Console.WriteLine("registered");
                my_connection.Close();
        }

        public static string ReferencesDetails_adding(string instr)
        {
            Console.Write(instr + " Provide refrence details\n");
            Console.WriteLine("\n");

            Console.Write("Fullname of the reference person: ");
            string reference_person_name = Console.ReadLine();
            Console.WriteLine("\n");

            Console.Write("Position of the reference person: ");
            string reference_person_position = Console.ReadLine();
            Console.WriteLine("\n");

            Console.Write("Address of the reference person: ");
            string reference_person_address = Console.ReadLine();
            Console.WriteLine("\n");

            Console.Write("Contact of the reference person: ");
            string references_person_contact_number = Console.ReadLine();
            Console.WriteLine("\n");

            Console.Write("Email of the reference person: ");
            string references_person_email = Console.ReadLine();
            Console.WriteLine("\n");

            Console.Write("Relation of the reference person: ");
            string reference_person_relation = Console.ReadLine();
            Console.WriteLine("\n");

            string reference_ID = references_person_contact_number + "" + reference_person_name;

            string SOL_String = "SELECT * FROM reference_specialist_data  ";

            int flag_Val = 0;
            my_connection.Open();

            MySqlCommand SQLCom = new MySqlCommand(SOL_String, my_connection);
            MySqlDataReader DataRead = SQLCom.ExecuteReader();

            string reference_ID1 = "";
            string references_person_email1 = "";
            while (DataRead.Read())
            {
                reference_ID1 = DataRead.GetString("referenceID");
                references_person_email1 = DataRead.GetString("emailid_of_references_person");
                if (reference_ID.Equals(reference_ID1) && references_person_email.Equals(references_person_email1))
                {
                    my_connection.Close();
                    return reference_ID;
                }
            }

            my_connection.Close();

            string Query_SQL2 = "INSERT INTO reference_specialist_data(referenceID, name_of_reference_person, position_of_reference_person," +
                " address_of_references_person, contact_number_of_references_person, emailid_of_references_person, relation_with_references_person )" +
                " VALUES ('" + reference_ID + "','" + reference_person_name + "','" + reference_person_position + "'," +
                "'" + reference_person_address + "','" + references_person_contact_number + "','" + references_person_email + "'," +
                "'" + reference_person_relation + "')";

            MySqlCommand SQL_Command2 = new MySqlCommand(Query_SQL2, my_connection);
            MySqlDataReader DataRead2;

            my_connection.Open();
            DataRead2 = SQL_Command2.ExecuteReader();      
            Console.WriteLine("Reference Added");
            Console.WriteLine("\n");

            my_connection.Close();


            return reference_ID;
        }


        public static void Available_rooms_displaying()
        {
            string SQL_String = "SELECT * FROM detailsbooking_room";
            string book_Days = "";
            string time_Slot = "";
            string enter_roomnumber = "";
            int flag_Val = 0;

            my_connection.Open();
            MySqlCommand SQL_Command = new MySqlCommand(SQL_String, my_connection);
            MySqlDataReader Data_Read = SQL_Command.ExecuteReader();
            int numberic = 1;

            Console.WriteLine("Available Rooms with Slot: \n");

            while (totalRoomNo >= numberic)
            {
                for(int c = 0; c < timeSessionSlot.Length; c++)
                {
                    if (Data_Read.Read())
                    {
                        while (Data_Read.Read())
                        {
                            enter_roomnumber = Data_Read.GetString("number_of_the_room");
                            time_Slot = Data_Read.GetString("set_slot_time");

                            if (!enter_roomnumber.Equals(numberic.ToString()) || !time_Slot.Equals(timeSessionSlot[c]))
                            {
                                Console.WriteLine(value: $"Room No: {numberic} , Slot: {timeSessionSlot[c]}");
                            }
                        }
                    }
                    else
                    {
                        string v = $"Room No: {numberic}";
                        Console.WriteLine(value: $"{v} , Session is: {timeSessionSlot[c]}");
                    }
                }
                Console.WriteLine("\n");
                numberic++;

            }
            
            my_connection.Close();
        }
        
        public static void Book_room_for_the_specialist()
        {
            int flag_Val = 0;
            DateTime current_Date = DateTime.Today;

            while (true)
            {
                Console.Write("Specialist ID: ");
                string sepc_ID = Console.ReadLine();

                string SQL_String = "SELECT * FROM register_specialist";

                my_connection.Open();
                MySqlCommand SQL_Command = new MySqlCommand(SQL_String, my_connection);
                MySqlDataReader Data_Reader = SQL_Command.ExecuteReader(); 

                string spec_ID1 = "";
                while (Data_Reader.Read())
                {
                    spec_ID1 = Data_Reader.GetString("spicID");
                    if (sepc_ID.Equals(spec_ID1))
                    {
                        flag_Val = 1;
                        break;
                    }
                }

                my_connection.Close();

                if(flag_Val == 0)
                {
                    Console.Write("Invalid ID");
                    continue;
                }

                string SQL_String1 = "SELECT * FROM detailsbooking_room";

                my_connection.Open();
                MySqlCommand SQL_Command1 = new MySqlCommand(SQL_String1, my_connection);
                MySqlDataReader Data_Reader1 = SQL_Command1.ExecuteReader();

                string spec_ID2 = "";
                while (Data_Reader1.Read())
                {
                    spec_ID2 = Data_Reader1.GetString("id_of_specialist");

                    if (sepc_ID.Equals(spec_ID2))
                    {
                        flag_Val = 0;
                        break;
                    }
                }

                my_connection.Close();

                if (flag_Val == 0)
                {
                    Console.WriteLine("You booked already.");
                    Console.WriteLine("\n");
                    continue;
                }


                Available_rooms_displaying();

                Console.Write("Room Number: ");
                Console.WriteLine("\n");
                int enter_roomnumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Select a time Slot\n");
                string time_slot_set = "";

                for (int c = 0; c < timeSessionSlot.Length; c++)
                {
                    Console.WriteLine(value: c + 1 + ". " + timeSessionSlot[c]);
                }
                int slot_Value = Convert.ToInt32(Console.ReadLine());

                switch (slot_Value)
                {
                    case 1:
                        time_slot_set = timeSessionSlot[slot_Value - 1];
                        break;

                    case 2:
                        time_slot_set = timeSessionSlot[slot_Value - 1];
                        break;

                    case 3:
                        time_slot_set = timeSessionSlot[slot_Value - 1];
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }


                string SQL_String2 = "SELECT * FROM detailsbooking_room";
                string time_Slot2 = "";
                string enter_roomnumber2 = "";
                int flag_Val2 = 0;

                my_connection.Open();
                MySqlCommand SQL_Command2 = new MySqlCommand(SQL_String2, my_connection);
                MySqlDataReader Data_Reader2 = SQL_Command2.ExecuteReader();

                while (Data_Reader2.Read())
                {
                    enter_roomnumber2 = Data_Reader2.GetString("number_of_the_room");
                    time_Slot2 = Data_Reader2.GetString("set_slot_time");

                    if (enter_roomnumber2.Equals(enter_roomnumber.ToString()) && time_slot_set.Equals(time_Slot2))
                    {
                        flag_Val2 = 1;
                        my_connection.Close();
                        break;
                    }
                }
                my_connection.Close();
                if (flag_Val2 == 1)
                {
                    Console.WriteLine("Slot Not Available.");
                    continue;
                }




                Console.WriteLine("Days to booking the room? > 10: ");
                int enter_value_of_days = Convert.ToInt32(Console.ReadLine());

                while (enter_value_of_days < 10)
                {
                    Console.WriteLine("Days to booking the room? > 10: ");
                    enter_value_of_days = Convert.ToInt32(Console.ReadLine());
                }

                int enter_value_of_days1 = enter_value_of_days - 1;

                Console.Write(value: $"Cost of room( £1000/ day), £{per_DayValue * enter_value_of_days}: ");
                int enter_price_of_room = Convert.ToInt32(value: Console.ReadLine());

                while (enter_price_of_room != (per_DayValue * enter_value_of_days))
                {
                    Console.WriteLine("Invalid Amount");
                    Console.WriteLine(value: $"Cost of room( £1000/ day), £{per_DayValue * enter_value_of_days}: ");
                    enter_price_of_room = Convert.ToInt32(Console.ReadLine());
                }


                Console.Write("Date(dd-MM-yyyy): ");
                DateTime first_Date = DateTime.ParseExact(s: Console.ReadLine(), format: "dd-MM-yyyy", provider: null);

                while (first_Date < current_Date)
                {
                    Console.WriteLine("Plese enter a next date");
                    Console.WriteLine("Date(dd-MM-yyyy): ");
                    first_Date = DateTime.ParseExact(s: Console.ReadLine(), format: "dd-MM-yyyy", provider: null);
                }

                for (int c = 0; c <= enter_value_of_days1; c++)
                {
                    if (first_Date.AddDays(c).ToString("ddd").Equals("Sun") || first_Date.AddDays(c).ToString("ddd").Equals("Sat"))
                    {
                        enter_value_of_days1++;
                    }
                }

                DateTime last_Day = first_Date.AddDays(enter_value_of_days1);

                string datefirst_1 = first_Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                string daylast_1 = last_Day.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);

                

                string SQL_Str3 = "INSERT INTO detailsbooking_room(id_of_specialist, number_of_the_room, set_slot_time," +
                    " value_of_days, price_of_room, date_first_1, day_last_1) " +
                    "VALUES ('" + sepc_ID + "','" + enter_roomnumber + "','" + time_slot_set + "','" + enter_value_of_days + "'," +
                    "'" + enter_price_of_room + "','" + datefirst_1 + "','" + daylast_1 + "')";

                MySqlCommand SQL_Command3 = new MySqlCommand(SQL_Str3, my_connection);
                MySqlDataReader Data_Reader3;

                my_connection.Open();
                Data_Reader3 = SQL_Command3.ExecuteReader();    

                my_connection.Close();
                break;
            }
        }


        public static void Book_appointment_for_the_patient()
        {
            int flag_Val = 0;
            DateTime current_Date = DateTime.Today;
            string last_Day = null;
            string timing_of_slot = null;
            while (true)
            {
                 string SQL_String = "SELECT * FROM detailsbooking_room JOIN register_specialist ON id_of_specialist = spicID";

                Console.WriteLine(pettren, "Doctor", "ID", "Time Slot\n");

                my_connection.Open();
                MySqlCommand SQL_Command = new MySqlCommand(SQL_String, my_connection);
                MySqlDataReader Data_Reader = SQL_Command.ExecuteReader();

                string special_ID = "";
                while (Data_Reader.Read())
                {
                    last_Day = Data_Reader.GetString("day_last_1");
                    DateTime daylast_1 = DateTime.ParseExact(s: Data_Reader.GetString("day_last_1"), format: "dd-MM-yyyy", provider: null);

                    if (daylast_1 > current_Date)
                        Console.WriteLine(pettren, arg0: Data_Reader.GetString("specialist_name"), arg1: Data_Reader.GetString("spicID"), arg2: Data_Reader.GetString("set_slot_time"));

                }
                my_connection.Close();
                Console.WriteLine("\n");

                Console.Write("Specialist ID: ");
                string specialist_person_id_number = Console.ReadLine();

                string SQL_String1 = "SELECT * FROM detailsbooking_room";

                my_connection.Open();
                MySqlCommand SQL_Command1 = new MySqlCommand(SQL_String1, my_connection);
                MySqlDataReader Data_Reader1 = SQL_Command1.ExecuteReader();

                string special_ID2 = "";
                while (Data_Reader1.Read())
                {
                    special_ID2 = Data_Reader1.GetString("id_of_specialist");
                    if (specialist_person_id_number.Equals(special_ID2))
                    {
                        last_Day = Data_Reader1.GetString("day_last_1");
                        timing_of_slot = Data_Reader1.GetString("set_slot_time");
                        flag_Val = 1;
                        break;
                    }
                }

                my_connection.Close();

                if (flag_Val == 0)
                {
                    Console.WriteLine("Incorrect ID");
                    continue;
                }


                Console.Write("Name of the patient: ");
                string name_of_the_patient = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("Contact number of the patient: ");
                string contact_number_details_of_patient = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write(value: " cost (£100) of the patient's: ");
                string appointment_total_cost = Console.ReadLine();
                Console.WriteLine("\n");

                if (!appointment_total_cost.Equals("100"))
                {
                    Console.WriteLine("Amount is not correct.");
                    continue;
                }




                string SQL_String3 = "INSERT INTO bookappoinment(specialist_ID_number, name_of_the_patient, currents_dates, slot, appointment_cost, patient_contact_number ) " +
                    "VALUES ('" + specialist_person_id_number + "','" + name_of_the_patient + "','" + current_Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) + "'," +
                    "'" + timing_of_slot + "','" + appointment_total_cost + "','" + contact_number_details_of_patient + "')";

                MySqlCommand SQL_Command3 = new MySqlCommand(SQL_String3, my_connection);
                MySqlDataReader Data_Reader3;

                my_connection.Open();
                Data_Reader3 = SQL_Command3.ExecuteReader();     

                my_connection.Close();
                break;

            }
            
        }

        public static string Appointment_Earnings_Calculate()
        {
            int total_Cost = 0;

            string apoint_Charge = "";
            int flag_Value = 0;
            while (true)
            {

                string SQL_String = "SELECT * FROM detailsbooking_room JOIN register_specialist ON id_of_specialist = spicID";

                Console.WriteLine(pettren, "Doctor", "ID", "Time info_slot_data\n");

                my_connection.Open();
                MySqlCommand SQL_Command = new MySqlCommand(cmdText: SQL_String, connection: my_connection);
                MySqlDataReader Data_Reader = SQL_Command.ExecuteReader();

                string special_ID = "";
                while (Data_Reader.Read())
                {
                    Console.WriteLine(pettren, 
                        arg0: Data_Reader.GetString("specialist_name"),
                        arg1: Data_Reader.GetString("spicID"),
                        arg2: Data_Reader.GetString("set_slot_time"));
                }
                my_connection.Close();
                Console.WriteLine("\n");

                const string Value_id = "Specialist ID: ";
                Console.WriteLine(Value_id);
                string specialist_person_id_number = Console.ReadLine();

                string SQL_String1 = "SELECT * FROM bookappoinment";

                my_connection.Open();
                MySqlCommand SQL_Command1 = new MySqlCommand(SQL_String1, my_connection);
                MySqlDataReader Data_Reader1 = SQL_Command1.ExecuteReader();
                string special_ID2 = "";
                while (Data_Reader1.Read())
                {
                    special_ID2 = Data_Reader1.GetString("specialist_ID_number");
                    if (specialist_person_id_number.Equals(special_ID2))
                    {
                        apoint_Charge = Data_Reader1.GetString("appointment_cost");
                        total_Cost += Convert.ToInt32(apoint_Charge);
                        flag_Value = 1;
                    }
                }

                my_connection.Close();

                if (flag_Value == 0)
                {
                    Console.WriteLine("InCorrect ID");
                    continue;
                }

                const string Val = ", Total Earning: ";
                return Value_id + specialist_person_id_number + Val + total_Cost;

            }
        }

    }

}
