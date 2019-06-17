-- phpMyAdmin SQL Dump
-- version 4.4.10
-- http://www.phpmyadmin.net
--
-- Host: localhost:3306
-- Generation Time: Jun 17, 2019 at 05:52 PM
-- Server version: 5.5.42
-- PHP Version: 5.6.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `blog_platform`
--
CREATE DATABASE IF NOT EXISTS `blog_platform` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin;
USE `blog_platform`;

-- --------------------------------------------------------

--
-- Table structure for table `Contact`
--

CREATE TABLE `Contact` (
  `ContactID` int(1) NOT NULL,
  `ContactMetod` varchar(1) COLLATE utf8_bin DEFAULT NULL,
  `Address` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `Prefix` varchar(5) COLLATE utf8_bin DEFAULT NULL,
  `Phone` varchar(5) COLLATE utf8_bin DEFAULT NULL,
  `citizenshipCard` varchar(15) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `Contact`
--

INSERT INTO `Contact` (`ContactID`, `ContactMetod`, `Address`, `Prefix`, `Phone`, `citizenshipCard`) VALUES
(1, 'F', 'El batan', '593', '99873', '1712654290'),
(2, 'E', 'ajtc16@gmail.com', '0', '0', '1712654290'),
(3, 'E', 'lmtc0293@hotmail.com', '0', '0', '1716654234');

-- --------------------------------------------------------

--
-- Table structure for table `Gender`
--

CREATE TABLE `Gender` (
  `GederID` int(1) NOT NULL,
  `GenderName` varchar(255) COLLATE utf8_bin DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `Gender`
--

INSERT INTO `Gender` (`GederID`, `GenderName`) VALUES
(1, 'Male'),
(2, 'Female');

-- --------------------------------------------------------

--
-- Table structure for table `Nationality`
--

CREATE TABLE `Nationality` (
  `NationalityID` int(1) NOT NULL,
  `CountryName` varchar(100) COLLATE utf8_bin DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `Nationality`
--

INSERT INTO `Nationality` (`NationalityID`, `CountryName`) VALUES
(1, 'Ecuador'),
(2, 'Argentina'),
(3, 'Chile'),
(4, 'United States');

-- --------------------------------------------------------

--
-- Table structure for table `Person`
--

CREATE TABLE `Person` (
  `PersonID` int(1) NOT NULL,
  `FirstName` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `LastName` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `birthday` date DEFAULT NULL,
  `GenderID` int(11) DEFAULT NULL,
  `CountryID` int(11) DEFAULT NULL,
  `ContactID` int(11) DEFAULT NULL,
  `citizenshipCard` varchar(15) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `Person`
--

INSERT INTO `Person` (`PersonID`, `FirstName`, `LastName`, `birthday`, `GenderID`, `CountryID`, `ContactID`, `citizenshipCard`) VALUES
(1, 'Antonio Jose', 'Teran Cevallos', '1989-05-16', 1, 1, 1, '1712654290'),
(2, 'Luis Miguel', 'Teran Cevallos', '1993-02-03', 1, 1, 3, '1716654234');

-- --------------------------------------------------------

--
-- Table structure for table `Post`
--

CREATE TABLE `Post` (
  `PostID` int(1) NOT NULL,
  `Text` varchar(500) COLLATE utf8_bin DEFAULT NULL,
  `DateCreated` date DEFAULT NULL,
  `DateModify` date DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `Active` int(1) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `Post`
--

INSERT INTO `Post` (`PostID`, `Text`, `DateCreated`, `DateModify`, `Status`, `UserID`, `Active`) VALUES
(1, 'este es mi primer Post publico', '2019-06-15', '2019-06-15', 2, 1, 0),
(2, 'este e sun post privado actualizado1212', '2019-06-15', '2019-06-17', 1, 1, 0),
(3, 'este e sun post Draft', '2019-06-15', '2019-06-15', 0, 1, 0),
(4, 'post publico de luis miguel', '2019-06-15', '2019-06-15', 2, 2, 0),
(5, 'post privado  de luis miguel', '2019-06-15', '2019-06-15', 1, 2, 0),
(6, 'post privado  de luis miguel 2', '2019-06-15', '2019-06-15', 1, 2, 0),
(7, 'hola a todos', '2019-06-15', '2019-06-15', 1, 3, 0),
(8, 'este es mi segundo Post publico y lo acabo de actualizar', '2019-06-16', '2019-06-16', 2, 1, 1),
(9, 'Prueba de update desde post', '2019-06-17', '2019-06-17', 1, 1, 1),
(10, 'post desde el front', '2019-06-17', '2019-06-17', 0, 0, 0),
(11, 'prueba 2018', '2019-06-17', '2019-06-17', 0, 1, 0),
(12, 'prueba 2019', '2019-06-17', '2019-06-17', 1, 1, 0),
(13, 'prueba 2020', '2019-06-17', '2019-06-17', 2, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `User`
--

CREATE TABLE `User` (
  `UserID` int(1) NOT NULL,
  `UserName` varchar(50) COLLATE utf8_bin NOT NULL,
  `Password` varchar(50) COLLATE utf8_bin NOT NULL,
  `status` varchar(1) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `User`
--

INSERT INTO `User` (`UserID`, `UserName`, `Password`, `status`) VALUES
(1, 'ajtc16', 'antonio1', 'A'),
(2, 'lmtc02', 'luis1993', 'A'),
(3, 'Flory32', 'contravene', 'A'),
(4, 'testUser', 'HOLA', 'A'),
(5, 'testUser1', 'cambiocontrasena', 'A'),
(6, 'juancho1234', 'nuevaPassword', 'D');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Contact`
--
ALTER TABLE `Contact`
  ADD PRIMARY KEY (`ContactID`);

--
-- Indexes for table `Gender`
--
ALTER TABLE `Gender`
  ADD PRIMARY KEY (`GederID`);

--
-- Indexes for table `Nationality`
--
ALTER TABLE `Nationality`
  ADD PRIMARY KEY (`NationalityID`);

--
-- Indexes for table `Person`
--
ALTER TABLE `Person`
  ADD PRIMARY KEY (`PersonID`);

--
-- Indexes for table `Post`
--
ALTER TABLE `Post`
  ADD PRIMARY KEY (`PostID`);

--
-- Indexes for table `User`
--
ALTER TABLE `User`
  ADD PRIMARY KEY (`UserID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Contact`
--
ALTER TABLE `Contact`
  MODIFY `ContactID` int(1) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `Gender`
--
ALTER TABLE `Gender`
  MODIFY `GederID` int(1) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `Nationality`
--
ALTER TABLE `Nationality`
  MODIFY `NationalityID` int(1) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `Person`
--
ALTER TABLE `Person`
  MODIFY `PersonID` int(1) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `Post`
--
ALTER TABLE `Post`
  MODIFY `PostID` int(1) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT for table `User`
--
ALTER TABLE `User`
  MODIFY `UserID` int(1) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
