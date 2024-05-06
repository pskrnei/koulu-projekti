using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SimpleDB : MonoBehaviour
{

    private string dbName = "URI=file:Player.db";
    // Start is called before the first frame update
    
    void Start()
    {
        CreateDB();
    }

    
    // Update is called once per frame
    void Update()
    {
        

       
    }
      
   
    public void CreateDB()
    {
        //Create the db connection
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            //Set up an object called "command" to allow db control
            using (var command = connection.CreateCommand())
            {
                //tekee pöydän "playerData" jos semmoista ei jo ole
                //4 fieldiä. id, username, password ja score
                
                command.CommandText = @"CREATE TABLE IF NOT EXISTS playerData (
                                        id INTEGER PRIMARY KEY,
                                        username VARCHAR(20) UNIQUE,
                                        password VARCHAR,
                                        score INTEGER
                                        );";
                command.ExecuteNonQuery();
            }
            
            connection.Close();
        }
    }

} 