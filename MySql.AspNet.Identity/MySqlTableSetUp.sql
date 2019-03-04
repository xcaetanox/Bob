
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(128) NOT NULL,
  `Name` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(128) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `UserId` (`UserId`),
  CONSTRAINT `ApplicationUser_Claims` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `UserId` varchar(128) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  KEY `ApplicationUser_Logins` (`UserId`),
  CONSTRAINT `ApplicationUser_Logins` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IdentityRole_Users` (`RoleId`),
  CONSTRAINT `ApplicationUser_Roles` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `IdentityRole_Users` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(128) NOT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `UserName` varchar(256) NOT NULL,
  `IdUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) DEFAULT NULL,
  `TipoPessoa` varchar(1) DEFAULT NULL,
  `CpfCnpj` varchar(14) DEFAULT NULL,
  `E_MAIL` varchar(100) DEFAULT NULL,
  `Rg` varchar(20) DEFAULT NULL,
  `DataNascimento` date DEFAULT NULL,
  `EstadoCivil` varchar(20) DEFAULT NULL,
  `Nascionalidade` varchar(20) DEFAULT NULL,
  `Profissao` varchar(20) DEFAULT NULL,
  `Sexo` varchar(1) DEFAULT NULL,
  `Cep` varchar(8) DEFAULT NULL,
  `Logradouro` varchar(100) DEFAULT NULL,
  `Numero` varchar(10) DEFAULT NULL,
  `Complemento` varchar(20) DEFAULT NULL,
  `Bairro` varchar(50) DEFAULT NULL,
  `Cidade` varchar(50) DEFAULT NULL,
  `Uf` varchar(2) DEFAULT NULL,
  `TelefoneResidencial` varchar(20) DEFAULT NULL,
  `TelefoneCelular` varchar(20) DEFAULT NULL,
  `Operadora` varchar(50) DEFAULT NULL,
  `TelefoneComercial` varchar(20) DEFAULT NULL,
  `ComoNosConheceu` varchar(50) DEFAULT NULL,
  `EmailAlternativo` varchar(50) DEFAULT NULL,
  `AceitoReceberEmails` tinyint(1) NOT NULL,
  `Status` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdUsuario` (`IdUsuario`),
  UNIQUE KEY `UK_UserName` (`UserName`),
  UNIQUE KEY `UK_CpfCnpj` (`CpfCnpj`),
  UNIQUE KEY `UK_Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('4b16bdca-6042-4242-a503-ec92ce261338','lucassimoes_@hotmail.com',1,'AON56s93E4p1joWh3SsB7Nlaf0JTdOcuHc2LVvn330lonJNlHv6628o26+IsRbc2xw==','6571ebaa-38c6-4bb7-9ba6-ca31ce2867f6','',0,0,NULL,1,0,'lucassimoes_@hotmail.com',10,'Lucas teste 2','F','12309855522',NULL,'2323423','1999-04-19','solteiro','brasileira','Profissão','M','04111081','Logradouro','333','Complemento','Bairro','Cidade','AC','11942000761','11942000761','vsdsds','11942000761','teste','lucassimoesmaistro@bol.com.br',1,''),('56f6294c-0d69-461d-80e3-dae2191af314','lucassimoes@sjaksj.com.br',0,'APzvRCLuyit3s08upWIo7bBFPZxT39wDbt+En3EqN10FY5y3ofEy+KOzMeUVz8UPLw==','f6e0240f-5f5e-4d34-82cb-dfdf319b5263',NULL,0,0,NULL,1,0,'lucassimoes@sjaksj.com.br',3,'Lucas de silva','F','1111111',NULL,'222222','0001-01-05','solteiro','Nascionalidade','aanlistga siustema','M','01532004','sao paulo','1212','1212','1212','1212','AC','1212','121212','212','1212','1221','amf.paulo@bol.com.br',1,NULL),('6e20c0ce-c4ee-4330-afe5-c6c592eb4bd9','clfsap@yahoo.com',0,'AN89x3FkrFih56VAUJI6HfefCqAHMujmZ2jqfsB8inVWdJ6/GFJk+KPWoqiR64gHNg==','828f8420-4575-47b2-b8f4-6cbf4f0152e3',NULL,0,0,NULL,1,0,'clfsap@yahoo.com',11,'Celso Luiz ','F','05868756895',NULL,'13430695','1970-03-03','lost','mandarim','consultor sap','M','04618032','Rua Edson','640','apto 51-crystal','Campo Belo','São Paulo','SP','3476949494','983487227','tim',NULL,NULL,NULL,1,NULL),('9b536554-bb14-403d-81be-b49dc3ad4112','ma_tec@yahoo.com.br',1,'AAiap0S0jtzdIC5LGCtn06tJUXJ56ljexQYLl6cGAGQPNM/pZ88is6MZT7KRYcl56w==','235d0781-82a8-449a-bbf4-7e8ef2b6d1b7','',0,0,NULL,1,0,'ma_tec@yahoo.com.br',9,'Matheus Santos','F','43104638861',NULL,'491597228','1993-04-21','Solteiro','Brasileiro','Desenvolvedor','M','02837000','Rua Domingos Vega','284','X','V,. João Batista','São Paulo','SP','11 39246806','11 994223831','CLARO','','Facebook','ma_tec@yahoo.com.br',1,''),('bdd35b72-3234-400c-9c00-491c354776c8','clfsap@yahoo.com.br',1,'AEucnsrsPqKKasNgHkqDlqrSx2paFl2/0o+5CFQSeE4jb4ZjJw3QTeVtd8o7dcaaeg==','42e7de2b-0d4c-4016-a7c7-5a319953c111','',0,0,NULL,1,0,'clfsap@yahoo.com.br',8,'Celso Luiz','F','05868756894',NULL,'13430695','1965-04-01','casado','brasileira','consultor','M','04618032','R. Edison','640','apto 51-Crystal','Campo Belo','São Paulo','SP','011-34760662','011-983487227','TIM','011-55036647','revista','materlife@materlife.com.br',1,'1'),('be12917d-6bde-46fe-8eab-8c5c9b96fcf8','lucassimoesmaistro@bol.com.br',1,'AMx9UHC9J9Xhs4hkE1kLibBwj3UxezGUwjLSTx64mQKbVLHL8x2UrfDlJ+PSTw9LGQ==','e4186c3d-c9f5-4d1e-b2b2-6e2d370c256d','',0,0,NULL,1,0,'lucassimoesmaistro@bol.com.br',6,'Lucas Simões Maistro','F','12121',NULL,'2121','1999-04-17','São Paulo','Nascionalidade','Profissão','M','05627020','Rua Padre Pacheco, 308','rr','eee','wwww','São Paulo','AC','11942000761','11942000761','vivo','11942000761','teste','lucassimoesmaistro@bol.com.br',1,''),('ffe1a9c6-273c-4244-8a63-752669a4667a','amf.paulo@gmail.com',1,'AIJhhwXxlBBN9m+x2Wu2kIX1ouuXhWTpIZInASfC/Tvo6Qpf8rcaktqkCj/CTn0mZw==','9feaf155-c7ab-46c5-8295-784fdf079cd2','',0,0,NULL,1,0,'amf.paulo@gmail.com',7,'1212','F','1111111112',NULL,'1221','1999-04-17','sol','b','a','M','0022121','dddd12','11','ap','aclima','dedeee','AC','1122223333','11212121','sdas','1133334444','fsdsfds','amf.paulo@gmail.com',1,'1');
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'DICANTODB'
--

--
-- Dumping routines for database 'DICANTODB'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-10 11:47:13
