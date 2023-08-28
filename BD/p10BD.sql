create database BD;
use BD;

create table Login(
id int primary key auto_increment,
usuario varchar(30) not null,
senha varchar(20) not null
);

insert into login(usuario, senha) values ('admin', '1234567');

select * from login;

desc login;