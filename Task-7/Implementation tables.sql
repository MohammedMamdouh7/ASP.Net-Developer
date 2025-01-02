		----MOVIE TABLES ----

		CREATE DATABASE TASK_7

		CREATE SCHEMA IMPL

CREATE TABLE IMPL.actor (
act_id INT PRIMARY KEY IDENTITY,  
act_fname VARCHAR(20),
act_lname VARCHAR(20),
act_gender VARCHAR(1),

)

CREATE TABLE IMPL.director (
dir_id INT PRIMARY KEY IDENTITY,
dir_lname VARCHAR(20),
dir_gender VARCHAR(20),

)

CREATE TABLE IMPL.movie (
mov_id INT PRIMARY KEY IDENTITY,  
mov_title VARCHAR(50),
mov_year INT,
mov_time INT,
mov_lang VARCHAR(50),
mov_dt_rel DATE,
mov_rel_country VARCHAR(5),

)

CREATE TABLE IMPL.reviewer (
rev_id INT PRIMARY KEY IDENTITY,  
rev_name VARCHAR(30),

)

CREATE TABLE IMPL.genres (
gen_id INT PRIMARY KEY IDENTITY,  
rev_title VARCHAR(20),

)

CREATE TABLE IMPL.movie_direction (
dir_id INT REFERENCES IMPL.director(dir_id) ON UPDATE CASCADE ON DELETE CASCADE ,  
mov_id INT REFERENCES IMPL.movie (mov_id) ON UPDATE CASCADE ON DELETE CASCADE ,
PRIMARY KEY(dir_id,mov_id),
)

CREATE TABLE IMPL.movie_cast (
act_id INT REFERENCES IMPL.actor (act_id) ON UPDATE CASCADE ON DELETE CASCADE  ,  
mov_id INT REFERENCES IMPL.movie (mov_id) ON UPDATE CASCADE ON DELETE CASCADE ,
role varchar(30),
PRIMARY KEY(act_id,mov_id),
)

CREATE TABLE IMPL.movie_genres (
mov_id INT REFERENCES IMPL.movie (mov_id) ON UPDATE CASCADE ON DELETE CASCADE ,
gen_id INT REFERENCES IMPL.genres (gen_id) ON UPDATE CASCADE ON DELETE CASCADE, 
PRIMARY KEY(mov_id,gen_id),
)

CREATE TABLE IMPL.rating (
mov_id INT REFERENCES IMPL.movie (mov_id) ON UPDATE CASCADE ON DELETE CASCADE ,
rev_id INT REFERENCES IMPL.reviewer (rev_id) ON UPDATE CASCADE ON DELETE CASCADE,
rev_stars INT,
num_of_ratings INT,
PRIMARY KEY(mov_id,rev_id),
)






