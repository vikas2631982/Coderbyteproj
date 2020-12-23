 public void savetask()
 { 
	try
        {
            using (TransactionScope scope = new TransactionScope())
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@taskname", t.Name));
                        cmd.Parameters.Add(new SqlParameter("@taskdesc", t.desc));
                        cmd.Parameters.Add(new SqlParameter("@taskstatus", t.ststus));
                        cmd.Parameters.Add(new SqlParameter("@taskstdate", t.stdate));
						 cmd.Parameters.Add(new SqlParameter("@taskenddate", t.enddate));
						  cmd.Parameters.Add(new SqlParameter("@region", t.region));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
        }

                scope.Complete();
            }
        }
		catch(Exception Ex)
	{
	}
 }
 
  public void edittask()
 { 
	try
        {
            using (TransactionScope scope = new TransactionScope())
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                       
                        cmd.Parameters.Add(new SqlParameter("@taskstatus", t.ststus));
                        cmd.Parameters.Add(new SqlParameter("@taskstdate", t.stdate));
						 cmd.Parameters.Add(new SqlParameter("@taskenddate", t.enddate));
						  cmd.Parameters.Add(new SqlParameter("@region", t.region));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
        }

                scope.Complete();
            }
        }
	catch(Exception Ex)
	{
	}
 }
 
  
  public List<task> showtask(string filter)
 { 
	try
        {
            string ConnectionString = "Integrated Security = SSPI; " +  
            "Initial Catalog= Maintanace; " + " Data source = localhost; ";  
            string SQL = string.foramt("SELECT * FROM Task where Status='{0}'",filter.Status)'  
  
            // create a connection object  
            SqlConnection conn = new SqlConnection(ConnectionString);  
  
            // Create a command object  
            SqlCommand cmd = new SqlCommand(SQL, conn);  
            conn.Open();  
  
            // Call ExecuteReader to return a DataReader  
            SqlDataReader reader = cmd.ExecuteReader();  
           
           List<task> lsttask=new  List<task>();
            while (reader.Read())  
            {  
				task ts=new task();
               ts.TaskId= Convert.ToInt32(reader["TaskId"]);  
               ts.TaskName=  Convert.ToString(reader["TaskName"]);  
                ts.TaskDescription=  Convert.ToString(reader["TaskDescription"]);  
                ts.TaskStatus= Convert.ToString(reader["TaskStatus"]); 
				lsttask.Add(ts)	;			
            }  
  
            //Release resources  
            reader.Close();  
            conn.Close();  
        }
		catch(Exception Ex)
	{
	}
 }