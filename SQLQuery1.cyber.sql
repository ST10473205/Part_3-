--creating database cyber_task --
create database cyber_tasks;

-- use the cyber_tasks database --
use [cyber_tasks];

-- creating table cyber_tasks --
CREATE TABLE Task (
     task_id int primary key  identity(1,1),
     task_name varchar(100),
     tasks_description varchar(255),
     task_dueDate Date,
     task_status varchar(50)
  );  
     
     -- select all from the table Task--
     select * from Task;