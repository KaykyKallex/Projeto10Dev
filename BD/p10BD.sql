create database BD;
use BD;

create table Login(
id int primary key auto_increment,
usuario varchar(30) not null,
senha varchar(20) not null
);