show databases;
use test;
show tables;

create database TestData;
use TestData;

CREATE TABLE model(no INT NOT NULL AUTO_INCREMENT PRIMARY KEY, name VARCHAR(1024) NOT NULL, update_date VARCHAR(128), update_user VARCHAR(128), data_header TEXT);
select * from model; 
show tables;

CREATE TABLE test_data(no INT NOT NULL AUTO_INCREMENT PRIMARY KEY, 
						model_name VARCHAR(1024) NOT NULL, 
						test_user VARCHAR(32), 
						start_time VARCHAR(128), 
						end_time VARCHAR(128), 
						serial_number VARCHAR(2048), 
						barcode VARCHAR(2048), 
						total_result VARCHAR(32), 
						test_data TEXT);
select * from test_data; 
show tables;

alter table model drop no;
alter table model add primary key (name);
delete from model;
delete from model where name='CN7';

