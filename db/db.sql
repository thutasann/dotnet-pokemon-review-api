-- MySQL dump 10.13  Distrib 8.0.34, for macos13 (arm64)
--
-- Host: localhost    Database: dotnet_pokemon
-- ------------------------------------------------------
-- Server version	8.2.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20240113044235_init','7.0.2'),('20240114040737_pokemon-add-field','7.0.2');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Categories`
--

DROP TABLE IF EXISTS `Categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Categories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Categories`
--

LOCK TABLES `Categories` WRITE;
/*!40000 ALTER TABLE `Categories` DISABLE KEYS */;
INSERT INTO `Categories` VALUES (1,'Cate One Updated'),(2,'Cate Two'),(3,'Cate Three'),(4,'Cate Four');
/*!40000 ALTER TABLE `Categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Countries`
--

DROP TABLE IF EXISTS `Countries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Countries` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Countries`
--

LOCK TABLES `Countries` WRITE;
/*!40000 ALTER TABLE `Countries` DISABLE KEYS */;
INSERT INTO `Countries` VALUES (1,'Country one'),(2,'Country Two'),(3,'Country Three'),(4,'Country Four');
/*!40000 ALTER TABLE `Countries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Owners`
--

DROP TABLE IF EXISTS `Owners`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Owners` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Gym` longtext NOT NULL,
  `CountryId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Owners_CountryId` (`CountryId`),
  CONSTRAINT `FK_Owners_Countries_CountryId` FOREIGN KEY (`CountryId`) REFERENCES `Countries` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Owners`
--

LOCK TABLES `Owners` WRITE;
/*!40000 ALTER TABLE `Owners` DISABLE KEYS */;
INSERT INTO `Owners` VALUES (1,'Owner One','Gym One',1),(2,'Owner Two','Gym Two',1),(3,'Owner Three','Gym Three',2);
/*!40000 ALTER TABLE `Owners` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PokemonCategories`
--

DROP TABLE IF EXISTS `PokemonCategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PokemonCategories` (
  `PokemonId` int NOT NULL,
  `CategoryId` int NOT NULL,
  PRIMARY KEY (`PokemonId`,`CategoryId`),
  KEY `IX_PokemonCategories_CategoryId` (`CategoryId`),
  CONSTRAINT `FK_PokemonCategories_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_PokemonCategories_Pokemons_PokemonId` FOREIGN KEY (`PokemonId`) REFERENCES `Pokemons` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PokemonCategories`
--

LOCK TABLES `PokemonCategories` WRITE;
/*!40000 ALTER TABLE `PokemonCategories` DISABLE KEYS */;
INSERT INTO `PokemonCategories` VALUES (1,1),(2,1),(3,2);
/*!40000 ALTER TABLE `PokemonCategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PokemonOwners`
--

DROP TABLE IF EXISTS `PokemonOwners`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PokemonOwners` (
  `PokemonId` int NOT NULL,
  `OwnerId` int NOT NULL,
  PRIMARY KEY (`PokemonId`,`OwnerId`),
  KEY `IX_PokemonOwners_OwnerId` (`OwnerId`),
  CONSTRAINT `FK_PokemonOwners_Owners_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `Owners` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_PokemonOwners_Pokemons_PokemonId` FOREIGN KEY (`PokemonId`) REFERENCES `Pokemons` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PokemonOwners`
--

LOCK TABLES `PokemonOwners` WRITE;
/*!40000 ALTER TABLE `PokemonOwners` DISABLE KEYS */;
INSERT INTO `PokemonOwners` VALUES (1,1),(2,1),(1,2);
/*!40000 ALTER TABLE `PokemonOwners` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Pokemons`
--

DROP TABLE IF EXISTS `Pokemons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Pokemons` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `BirthDate` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Pokemons`
--

LOCK TABLES `Pokemons` WRITE;
/*!40000 ALTER TABLE `Pokemons` DISABLE KEYS */;
INSERT INTO `Pokemons` VALUES (1,'Pokemon 1','2024-01-01 00:00:00.000000'),(2,'Pokemon Two','2024-01-01 00:00:00.000000'),(3,'Pokemon Three','2024-01-01 00:00:00.000000');
/*!40000 ALTER TABLE `Pokemons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Reviewers`
--

DROP TABLE IF EXISTS `Reviewers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Reviewers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` longtext NOT NULL,
  `LastName` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Reviewers`
--

LOCK TABLES `Reviewers` WRITE;
/*!40000 ALTER TABLE `Reviewers` DISABLE KEYS */;
INSERT INTO `Reviewers` VALUES (1,'Reviewer','One'),(2,'Reviewer','Two'),(3,'Reviewer','Three'),(4,'Reviewer','Four');
/*!40000 ALTER TABLE `Reviewers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Reviews`
--

DROP TABLE IF EXISTS `Reviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Reviews` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` longtext NOT NULL,
  `Text` longtext NOT NULL,
  `ReviewerId` int NOT NULL,
  `PokemonId` int NOT NULL,
  `Rating` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Reviews_PokemonId` (`PokemonId`),
  KEY `IX_Reviews_ReviewerId` (`ReviewerId`),
  CONSTRAINT `FK_Reviews_Pokemons_PokemonId` FOREIGN KEY (`PokemonId`) REFERENCES `Pokemons` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Reviews_Reviewers_ReviewerId` FOREIGN KEY (`ReviewerId`) REFERENCES `Reviewers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Reviews`
--

LOCK TABLES `Reviews` WRITE;
/*!40000 ALTER TABLE `Reviews` DISABLE KEYS */;
INSERT INTO `Reviews` VALUES (1,'Review One','This is Review One',1,1,100),(2,'Review Two','This is Review Two',1,1,200),(3,'Review Three','This is Review Three',2,1,300),(4,'Review Four','This is Review Four',2,2,400);
/*!40000 ALTER TABLE `Reviews` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-14 21:01:53
