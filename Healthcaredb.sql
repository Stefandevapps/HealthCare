-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: May 22, 2019 at 01:10 PM
-- Server version: 10.1.19-MariaDB
-- PHP Version: 5.6.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `healthcaredb`
--

-- --------------------------------------------------------

--
-- Table structure for table `bookappoinment`
--

CREATE TABLE `bookappoinment` (
  `ap_ID` int(11) NOT NULL,
  `specialist_ID_number` varchar(50) NOT NULL,
  `name_of_the_patient` varchar(50) NOT NULL,
  `currents_dates` varchar(50) NOT NULL,
  `info_slot_data` varchar(50) NOT NULL,
  `appointment_cost` int(11) NOT NULL,
  `patient_contact_number` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `detailsbooking_room`
--

CREATE TABLE `detailsbooking_room` (
  `booking_ID` int(11) NOT NULL,
  `id_of_specialist` varchar(50) NOT NULL,
  `number_of_the_room` varchar(50) NOT NULL,
  `set_slot_time` varchar(50) NOT NULL,
  `value_of_days` int(11) NOT NULL,
  `price_of_room` int(11) NOT NULL,
  `date_first_1` varchar(20) NOT NULL,
  `day_last_1` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detailsbooking_room`
--

INSERT INTO `detailsbooking_room` (`booking_ID`, `id_of_specialist`, `number_of_the_room`, `set_slot_time`, `value_of_days`, `price_of_room`, `date_first_1`, `day_last_1`) VALUES
(11, '12', '11', 'Time: 12:00 NOON – 5:00 PM', 12, 12000, '25-05-2019', '11-06-2019');

-- --------------------------------------------------------

--
-- Table structure for table `reference_specialist_data`
--

CREATE TABLE `reference_specialist_data` (
  `referenceID` varchar(50) NOT NULL,
  `name_of_reference_person` varchar(50) NOT NULL,
  `position_of_reference_person` varchar(50) NOT NULL,
  `address_of_references_person` varchar(50) NOT NULL,
  `contact_number_of_references_person` varchar(50) NOT NULL,
  `emailid_of_references_person` varchar(50) NOT NULL,
  `relation_with_references_person` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reference_specialist_data`
--

INSERT INTO `reference_specialist_data` (`referenceID`, `name_of_reference_person`, `position_of_reference_person`, `address_of_references_person`, `contact_number_of_references_person`, `emailid_of_references_person`, `relation_with_references_person`) VALUES
('5456376548Trent Boult', 'Trent Boult', 'Doctor', 'WI', '5456376548', 'boult@demo.com', 'Friend'),
('7667655654Ross Taylor', 'Ross Taylor', 'Doctor', 'AUS', '7667655654', 'ross@demo.com', 'friend'),
('9889877876Martin Guptil', 'Martin Guptil', 'Doctor', 'NZ', '9889877876', 'guptil@demo.com', 'Friend');

-- --------------------------------------------------------

--
-- Table structure for table `register_specialist`
--

CREATE TABLE `register_specialist` (
  `spicID` int(11) NOT NULL,
  `specialist_name` varchar(50) NOT NULL,
  `MeritalStatus_specialist` varchar(50) NOT NULL,
  `gender` varchar(50) NOT NULL,
  `DOB` varchar(50) NOT NULL,
  `specialist_contact_address` varchar(50) NOT NULL,
  `specialist_contact_number` varchar(50) NOT NULL,
  `emergency_contact_number` varchar(50) NOT NULL,
  `specialist_higher_education` varchar(50) NOT NULL,
  `specialist_training_certificate` varchar(50) NOT NULL,
  `specialist_membership` varchar(50) NOT NULL,
  `specialist_two_id_documents` varchar(50) NOT NULL,
  `specialist_photo_id` varchar(50) NOT NULL,
  `specialist_crb` varchar(50) NOT NULL,
  `specialist_first_person_reference_name` varchar(50) NOT NULL,
  `specialist_second_person_reference_name` varchar(50) NOT NULL,
  `specialist_third_person_reference_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `register_specialist`
--

INSERT INTO `register_specialist` (`spicID`, `specialist_name`, `MeritalStatus_specialist`, `gender`, `DOB`, `specialist_contact_address`, `specialist_contact_number`, `emergency_contact_number`, `specialist_higher_education`, `specialist_training_certificate`, `specialist_membership`, `specialist_two_id_documents`, `specialist_photo_id`, `specialist_crb`, `specialist_first_person_reference_name`, `specialist_second_person_reference_name`, `specialist_third_person_reference_name`) VALUES
(12, 'Kane Williamson', 'Married', 'Male', '12-April-1978', 'NZ', '0908070605', '1213141516', 'MD', 'PHD', 'Doctor Association', 'DL UN', 'n', 'TGY56T', '9889877876Martin Guptil', '7667655654Ross Taylor', '5456376548Trent Boult');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bookappoinment`
--
ALTER TABLE `bookappoinment`
  ADD PRIMARY KEY (`ap_ID`);

--
-- Indexes for table `detailsbooking_room`
--
ALTER TABLE `detailsbooking_room`
  ADD PRIMARY KEY (`booking_ID`);

--
-- Indexes for table `reference_specialist_data`
--
ALTER TABLE `reference_specialist_data`
  ADD PRIMARY KEY (`referenceID`);

--
-- Indexes for table `register_specialist`
--
ALTER TABLE `register_specialist`
  ADD PRIMARY KEY (`spicID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bookappoinment`
--
ALTER TABLE `bookappoinment`
  MODIFY `ap_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `detailsbooking_room`
--
ALTER TABLE `detailsbooking_room`
  MODIFY `booking_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `register_specialist`
--
ALTER TABLE `register_specialist`
  MODIFY `spicID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
