
create database railway;
use railway;
create table train(
idtrain int not null primary key ,
type nvarchar(45) not null,
begnamecountry nvarchar(45) not null,
endnamecountry nvarchar(45) not null ,
duration nvarchar(45) not null);

create table country(
conname nvarchar(45) primary key,
id int NOT NULL AUTO_INCREMENT unique
);

create table account(username nvarchar(30) primary key,
firstname nvarchar(60) not null,
gender char(10) not null,
nationality nvarchar(30) not null,
idtype nvarchar(30) not null,
id nvarchar(30) unique,
password varchar(30) not null ,
email varchar(30) unique,
address  nvarchar(30) null );

create table pridge(time Time not null ,
idtrain int not null,
conname nvarchar(45) null ,
FOREIGN KEY (idtrain) REFERENCES train(idtrain),
FOREIGN KEY (conname) REFERENCES country(conname));


create table ticket(idticket int primary key,
name nvarchar(45) not null,
seatnum int not null,
date Date not null,
arrivecon nvarchar(45) not null,
goconnvarchar nvarchar(45) not null ,
username nvarchar(30) not null ,
idtrain int not null ,
carriagenum int not null,
reserverd_date Date not null,
constraint un1 unique(seatnum,carriagenum,idtrain,date),
FOREIGN KEY (idtrain) REFERENCES train(idtrain),
FOREIGN KEY (username) REFERENCES account(username));

insert into train values(2007,'Vip','اسوان','القاهره' ,'12 :55');
insert into train values(2015,'Vip','اسوان','القاهره','12 : 20');
insert into train values(977,'Vip','الاقصر','لقاهره','9 : 55 ');
insert into train values(2009,'Vip','اسوان','لقاهره','12 : 35');
insert into train values(981,'Vip','اسوان','لقاهره','14 : 5 ');
insert into train values(979,'Vip','اسيوط','القاهره','6  : 20 ');
insert into train values(935,'Vip','لاقصر','لاسكندريه','12  : 25' );
insert into train values(934,'Vip','الاسكندريه','لاقصر','12:  45');
insert into train values(978,'Vip','القاهره','اسيوط','6: 20');
insert into train values(980,'Vip','القاهره','اسوان','14 : 40 ');
insert into train values(2006,'Vip','القاهره','اسوان','12  : 25');
insert into train values(2014,'Vip','القاهره','اسوان','12 : 40 ');
insert into train values(976,'Vip','القاهره','الاقصر','10  : 15');
insert into train values(2008,'Vip','الاسكندريه','اسوان','15: 45');
insert into train values(1902,'مكيف','القاهره','اسوان','13:00');
insert into train values(982,'مكيف','القاهره','اسوان','14:25');
insert into train values(986,'مكيف','القاهره','الاقصر','11:00');
insert into train values(970,'مكيف','القاهره','سوهاج','7:30');
insert into train values(990,'مكيف','القاهره','سوهاج','8:00');
insert into train values(972,'مكيف','القاهره','اسيوط','7:15');
insert into train values(988,'مكيف','القاهره','اسوان','12:50');
insert into train values(88,'مكيف','الاسكندريه','اسوان','17:55');
insert into train values(996,'مكيف','القاهره','سوان','13:25');
insert into train values(890,'مكيف','القاهره','سوهاج','7:0');
insert into train values(1903,'مكيف','اسوان','القاهره','12:50');
insert into train values(871,'مكيف','اسيوط','القاهره','5:55');
insert into train values(997,'مكيف','اسوان','القاهره','13:55');
insert into train values(89,'مكيف','اسوان','الاسكندريه','16:50');
insert into train values(989,'مكيف','القاهره','الاقصر','11:00');
insert into train values(971,'مكيف','سوهاج','القاهره','7:45');
insert into train values(991,'مكيف','سوهاج','القاهره','7:45');
insert into train values(987,'مكيف','الاقصر','القاهره','10:45');
insert into train values(891,'مكيف','اسوان','القاهره','14:5');
insert into train values(983,'مكيف','اسوان','القاهره','14:10');



insert into country (conname)values('الاسكندريه');
insert into country  (conname)values('سيدى جابر');
insert into country  (conname)values('بورسعيد');
insert into country  (conname)values('دمياط');
insert into country  (conname)values('دمنهور');
insert into country  (conname)values('المنصوره');
insert into country  (conname)values('طنطا');
insert into country  (conname)values('الاسماعليه');
insert into country  (conname)values('الزقازيق');
insert into country  (conname)values('بنها');
insert into country  (conname)values('القاهره');
insert into country  (conname)values('الجيزه');
insert into country  (conname)values('بنى سويف');
insert into country  (conname)values('المنيا');
insert into country  (conname)values('اسيوط');
insert into country  (conname)values('سوهاج');
insert into country  (conname)values('قنا');
insert into country  (conname)values('الاقصر');
insert into country  (conname)values('اسوان');

Insert into pridge values('21:00:00',2014,'القاهره');
Insert into pridge values('21:25:00',2014,'الجيزه');

Insert into pridge values('00:20:00',2014,'المنيا');

Insert into pridge values('02:00:00',2014,'اسيوط');

Insert into pridge values('03:45:00',2014,'سوهاج');

Insert into pridge values('05:45:00',2014,'قنا');

Insert into pridge values('06:40:00',2014,'الاقصر');

Insert into pridge values('09:40:00',2014,'اسوان');

insert into pridge values('05:30:00',981,'اسوان');
insert into pridge values('09:10:00',981,'الاقصر');
insert into pridge values('12:55:00',981,'سوهاج');
insert into pridge values('14:35:00',981,'اسيوط');
insert into pridge values('16:25:00',981,'المنيا');
insert into pridge values('17:54:00',981,'بنى سويف');
insert into pridge values('19:15:00',981,'الجيزه');
insert into pridge values('19:35:00',981,'القاهره');
insert into pridge values('15:00:00',2007,'اسوان');
insert into pridge values('18:15:00',2007,'الاقصر');
insert into pridge values('19:10:00',2007,'قنا');
insert into pridge values('21:35:00',2007,'سوهاج');
insert into pridge values('23:05:00',2007,'اسيوط');
insert into pridge values('00:55:00',2007,'المنيا');
insert into pridge values('03:35:00',2007,'الجيزه');
insert into pridge values('03:55:00',2007,'القاهره');
insert into pridge values('16:00:00',2015,'اسوان');
insert into pridge values('19:10:00',2015,'الاقصر');
insert into pridge values('20:00:00',2015,'قنا');
insert into pridge values('22:00:00',2015,'سوهاج');
insert into pridge values('23:30:00',2015,'اسيوط');
insert into pridge values('01:20:00',2015,'المنيا');
insert into pridge values('04:00:00',2015,'الجيزه');
insert into pridge values('04:20:00',2015,'القاهره');
insert into pridge values('19:25:00',977,'الاقصر');
insert into pridge values('20:20:00',977,'قنا');
insert into pridge values('22:35:00',977,'سوهاج');
insert into pridge values('00:10:00',977,'اسيوط');
insert into pridge values('01:55:00',977,'المنيا');
insert into pridge values('03:19:00',977,'بنى سويف');
insert into pridge values('04:40:00',977,'الجيزه');
insert into pridge values('05:20:00',977,'القاهره');
insert into pridge values('23:09:00',977,'طنطا');
insert into pridge values('18:10:00',2009,'اسوان');
insert into pridge values('21:20:00',2009,'الاقصر');
insert into pridge values('22:15:00',2009,'قنا');
insert into pridge values('00:35:00',2009,'سوهاج');
insert into pridge values('02:05:00',2009,'اسيوط');
insert into pridge values('06:25:00',2009,'الجيزه');
insert into pridge values('06:45:00',2009,'القاهره');
insert into pridge values('05:30:00',981,'اسوان');
insert into pridge values('09:05:00',981,'الاقصر');

insert into pridge values('00:20:00',1902,'القاهره');
insert into pridge values('00:50:00',1902,'الجيزه');
insert into pridge values('05:15:00',1902,'اسيوط');
insert into pridge values('06:20:00',1902,'طنطا');
insert into pridge values('07:05:00',1902,'سوهاج');
insert into pridge values('09:20:00',1902,'قنا');
insert into pridge values('10:20:00',1902,'الاقصر');
insert into pridge values('13:20:00',1902,'اسوان');
insert into pridge values('12:00:00',982,'القاهره');
insert into pridge values('12:30:00',982,'الجيزه');
insert into pridge values('13:54:00',982,'بنى سويف');
insert into pridge values('15:30:00',982,'المنيا');
insert into pridge values('17:25:00',982,'اسيوط');
insert into pridge values('18:30:00',982,'طنطا');
insert into pridge values('19:15:00',982,'سوهاج');
insert into pridge values('22:00:00',982,'قنا');
insert into pridge values('23:10:00',982,'الاقصر');
insert into pridge values('02:25:00',982,'اسوان');
insert into pridge values('13:00:00',986,'القاهره');
insert into pridge values('13:30:00',986,'الجيزه');
insert into pridge values('14:47:00',986,'بنى سويف');
insert into pridge values('16:30:00',986,'المنيا');
insert into pridge values('18:40:00',986,'اسيوط');
insert into pridge values('20:15:00',986,'سوهاج');
insert into pridge values('19:36:00',986,'طنطا');
insert into pridge values('23:00:00',986,'قنا');
insert into pridge values('00:00:00',986,'الاقصر');



insert into pridge values('05:30:00',981,'اسوان');
insert into pridge values('09:10:00',981,'الاقصر');
insert into pridge values('12:55:00',981,'سوهاج');
insert into pridge values('14:35:00',981,'اسيوط');
insert into pridge values('16:25:00',981,'المنيا');
insert into pridge values('17:54:00',981,'بنى سويف');
insert into pridge values('19:15:00',981,'الجيزه');
insert into pridge values('19:35:00',981,'القاهره');
insert into pridge values('15:00:00',2007,'اسوان');
insert into pridge values('18:15:00',2007,'الاقصر');
insert into pridge values('19:10:00',2007,'قنا');
insert into pridge values('21:35:00',2007,'سوهاج');
insert into pridge values('23:05:00',2007,'اسيوط');
insert into pridge values('00:55:00',2007,'المنيا');
insert into pridge values('03:35:00',2007,'الجيزه');
insert into pridge values('03:55:00',2007,'القاهره');
insert into pridge values('16:00:00',2015,'اسوان');
insert into pridge values('19:10:00',2015,'الاقصر');
insert into pridge values('20:00:00',2015,'قنا');
insert into pridge values('22:00:00',2015,'سوهاج');
insert into pridge values('23:30:00',2015,'اسيوط');
insert into pridge values('01:20:00',2015,'المنيا');
insert into pridge values('04:00:00',2015,'الجيزه');
insert into pridge values('04:20:00',2015,'القاهره');
insert into pridge values('19:25:00',977,'الاقصر');
insert into pridge values('20:20:00',977,'قنا');
insert into pridge values('22:35:00',977,'سوهاج');
insert into pridge values('00:10:00',977,'اسيوط');
insert into pridge values('01:55:00',977,'المنيا');
insert into pridge values('03:19:00',977,'بنى سويف');
insert into pridge values('04:40:00',977,'الجيزه');
insert into pridge values('05:20:00',977,'القاهره');
insert into pridge values('23:09:00',977,'طنطا');
insert into pridge values('18:10:00',2009,'اسوان');
insert into pridge values('21:20:00',2009,'الاقصر');
insert into pridge values('22:15:00',2009,'قنا');
insert into pridge values('00:35:00',2009,'سوهاج');
insert into pridge values('02:05:00',2009,'اسيوط');
insert into pridge values('06:25:00',2009,'الجيزه');
insert into pridge values('06:45:00',2009,'القاهره');
insert into pridge values('05:30:00',981,'اسوان');
insert into pridge values('09:05:00',981,'الاقصر');
insert into pridge values('10:15:00',981,'قنا');
insert into pridge values('12:55:00',981,'سوهاج');
insert into pridge values('13:29:00',981,'طنطا');
insert into pridge values('14:35:00',981,'اسيوط');
insert into pridge values('16:25:00',981,'المنيا');
insert into pridge values('17:54:00',981,'بنى سويف');
insert into pridge values('19:15:00',981,'الجيزه');
insert into pridge values('19:35:00',981,'القاهره');
insert into pridge values('00:20:00',1902,'القاهره');
insert into pridge values('00:50:00',1902,'الجيزه');
insert into pridge values('05:15:00',1902,'اسيوط');
insert into pridge values('06:20:00',1902,'طنطا');
insert into pridge values('07:05:00',1902,'سوهاج');
insert into pridge values('09:20:00',1902,'قنا');
insert into pridge values('10:20:00',1902,'الاقصر');
insert into pridge values('13:20:00',1902,'اسوان');
insert into pridge values('12:00:00',982,'القاهره');
insert into pridge values('12:30:00',982,'الجيزه');
insert into pridge values('13:54:00',982,'بنى سويف');
insert into pridge values('15:30:00',982,'المنيا');
insert into pridge values('17:25:00',982,'اسيوط');
insert into pridge values('18:30:00',982,'طنطا');
insert into pridge values('19:15:00',982,'سوهاج');
insert into pridge values('22:00:00',982,'قنا');
insert into pridge values('23:10:00',982,'الاقصر');
insert into pridge values('02:25:00',982,'اسوان');
insert into pridge values('13:00:00',986,'القاهره');
insert into pridge values('13:30:00',986,'الجيزه');
insert into pridge values('14:47:00',986,'بنى سويف');
insert into pridge values('16:30:00',986,'المنيا');
insert into pridge values('18:40:00',986,'اسيوط');
insert into pridge values('20:15:00',986,'سوهاج');
insert into pridge values('19:36:00',986,'طنطا');
insert into pridge values('23:00:00',986,'قنا');
insert into pridge values('00:00:00',986,'الاقصر');

