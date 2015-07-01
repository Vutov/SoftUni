-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jul 01, 2015 at 07:08 PM
-- Server version: 5.6.21
-- PHP Version: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `trainings`
--

-- --------------------------------------------------------

--
-- Table structure for table `courses`
--

CREATE TABLE IF NOT EXISTS `courses` (
`id` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `description` varchar(150) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=110 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`id`, `name`, `description`) VALUES
(101, 'Java Basics', 'Learn more at https://softuni.bg/courses/java-basics/'),
(102, 'English for beginners', '3-month English course'),
(103, 'Salsa: First Steps', NULL),
(104, 'Avancée Français', 'French language: Level III'),
(105, 'HTML & CSS', NULL),
(106, 'Databases', 'Introductionary course in databases, SQL, MySQL, SQL Server and MongoDB'),
(107, 'C# Programming', 'Intro C# corse for beginners'),
(108, 'Tango dances', NULL),
(109, 'Spanish, Level II', 'Aprender Español');

-- --------------------------------------------------------

--
-- Table structure for table `course_timetable`
--

CREATE TABLE IF NOT EXISTS `course_timetable` (
`id` int(11) NOT NULL,
  `timetable_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `timetable`
--

CREATE TABLE IF NOT EXISTS `timetable` (
`id` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `training_id` int(11) NOT NULL,
  `start_date` date NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `timetable`
--

INSERT INTO `timetable` (`id`, `course_id`, `training_id`, `start_date`) VALUES
(43, 101, 1, '2015-01-24'),
(44, 101, 5, '2015-02-21'),
(45, 102, 6, '2015-01-14'),
(46, 102, 4, '2014-12-31'),
(47, 102, 2, '2015-02-07'),
(48, 102, 1, '2015-02-26'),
(49, 102, 3, '2015-02-22'),
(50, 103, 7, '2015-02-25'),
(51, 103, 3, '2015-02-19'),
(52, 104, 5, '2014-12-31'),
(53, 104, 1, '2015-03-23'),
(54, 104, 3, '2015-03-25'),
(55, 105, 5, '2015-01-18'),
(56, 105, 4, '2015-03-16'),
(57, 105, 3, '2015-04-10'),
(58, 105, 2, '2015-03-12'),
(59, 106, 5, '2015-02-19'),
(60, 107, 2, '2015-02-20'),
(61, 107, 1, '2015-01-20'),
(62, 107, 3, '2015-03-01'),
(63, 109, 6, '2015-01-13');

-- --------------------------------------------------------

--
-- Table structure for table `training_centers`
--

CREATE TABLE IF NOT EXISTS `training_centers` (
`id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `description` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `url` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `training_centers`
--

INSERT INTO `training_centers` (`id`, `name`, `description`, `url`) VALUES
(1, 'Sofia Learning', NULL, 'http://sofialearning.org'),
(2, 'Varna Innovations & Learning', 'Innovative training center, located in Varna. Provides trainings in software development and foreign', 'http://vil.edu'),
(3, 'Plovdiv Trainings & Inspiration', NULL, NULL),
(4, 'Sofia West Adult Trainings', 'The best training center in Lyulin', 'https://sofiawest.bg'),
(5, 'Software Trainings Ltd.', NULL, 'http://softtrain.eu'),
(6, 'Polyglot Language School', 'English, French, Spanish and Russian language courses', NULL),
(7, 'Modern Dances Academy', 'Learn how to dance!', 'http://danceacademy.bg');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `courses`
--
ALTER TABLE `courses`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `course_timetable`
--
ALTER TABLE `course_timetable`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `timetable`
--
ALTER TABLE `timetable`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `training_centers`
--
ALTER TABLE `training_centers`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `courses`
--
ALTER TABLE `courses`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=110;
--
-- AUTO_INCREMENT for table `course_timetable`
--
ALTER TABLE `course_timetable`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `timetable`
--
ALTER TABLE `timetable`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=64;
--
-- AUTO_INCREMENT for table `training_centers`
--
ALTER TABLE `training_centers`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
