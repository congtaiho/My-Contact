using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modell;


namespace DataAccess
{
    public class DataConnect
    {
        static readonly String connString = @"Data Source=751FJW2\SQLEXPRESS;Initial Catalog=gestion_contacts;Integrated Security=True;Connect Timeout=30";
        public static void ConnectionData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString: connString))
            {
                conn.Open();
                Console.WriteLine("Connexion success!");
            }
        }
        public static bool CheckLogin(string counrriel, string passWord)
        {
            //bool isLogin = false;
            using (SqlConnection conn = new SqlConnection(connectionString: connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM utilisateurs WHERE courriel=@Courriel AND mot_de_passe=@Mot_de_passe ";
                    cmd.Parameters.AddWithValue("@Courriel", counrriel);
                    cmd.Parameters.AddWithValue("@Mot_de_passe", passWord);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;

                    }
                }
            }
        }
        public static bool AddContact(Contact contact)
        {
            string name = contact.Nom;
            string prenom = contact.Prenom;
            string telephone = contact.Telephone;
            bool addContact = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = @"INSERT INTO contacts(nom, prenom, telephone) VALUES(@nom, @prenom,@telephone)";
                        cmd.Parameters.AddWithValue("@nom", name);
                        cmd.Parameters.AddWithValue("@prenom", prenom);
                        cmd.Parameters.AddWithValue("@telephone", telephone);

                        cmd.ExecuteNonQuery();

                    }
                }
                addContact = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message: {e.Message}");
            }
            return addContact;
        }


        public static List<Contact> SearchByyName(string nameToSearch)
        {
            List<Contact> contacts = new List<Contact>(); ;
            using (SqlConnection connection = new SqlConnection(connectionString: connString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"select * from contacts where nom like '%'+ @Nom + '%'";
                    cmd.Parameters.Add(new SqlParameter("@Nom", nameToSearch));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contact cont = new Contact();
                            cont.Id = reader.GetInt32(0);
                            cont.Nom = reader.GetString(1);
                            cont.Prenom = reader.GetString(2);
                            cont.Telephone = reader.GetString(3);
                            if (!reader.IsDBNull(4))
                            {
                                cont.Courriel = reader.GetString(4);
                            }
                            else
                            {
                                cont.Courriel = null;
                            }
                            contacts.Add(cont);
                        }

                    }
                }
            }
            return contacts;
        }


        public static List<Contact> ShowContacts()
        {
            List<Contact> contacts = new List<Contact>();
            using (SqlConnection conn = new SqlConnection(connectionString: connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM contacts";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contact conta = new Contact();
                            conta.Id = reader.GetInt32(0);
                            conta.Nom = reader.GetString(1);
                            conta.Prenom = reader.GetString(2);
                            conta.Telephone = reader.GetString(3);

                            if (!reader.IsDBNull(4))
                            {
                                conta.Courriel = reader.GetString(4);
                            }
                            else
                            {
                                conta.Courriel = null;
                            }
                            contacts.Add(conta);
                        }
                    }
                }
            }
            return contacts;
        }
        public static bool DeleteContactById(int Id)
        {
            bool deleteContact = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = @"DELETE FROM contacts WHERE id=@ID";
                        cmd.Parameters.Add(new SqlParameter("@ID", Id));
                        cmd.ExecuteNonQuery();

                    }
                }
                deleteContact = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message: {e.Message}");
            }
            return deleteContact;
        }
        public static void ShowAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString: connString))
            {
                connection.Open();
                string query = "select id,nom,prenom,telephone,courriel_utilisateur from contacts ORDER BY nom ASC";
                SqlCommand createCommand = new SqlCommand(query, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable table = new DataTable("contacts");
                dataAdp.Fill(table);
            }
        }
        public static bool EditContact(Contact contact)
        {
            string name = contact.Nom;
            string prenom = contact.Prenom;
            string telephone = contact.Telephone;
            bool editContact = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = @"UPDATE contacts SET nom=@nom, prenom=@prenom, telephone=@telephone WHERE nom=@nom";
                        
                        cmd.Parameters.AddWithValue("@nom", name);
                        cmd.Parameters.AddWithValue("@prenom", prenom);
                        cmd.Parameters.AddWithValue("@telephone", telephone);

                        cmd.ExecuteNonQuery();

                    }
                }
                editContact = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message: {e.Message}");
            }
            return editContact;
        }


        
    }
}
