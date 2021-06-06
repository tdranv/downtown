-- --------------------------------------------------------
-- Host:                         f80b6byii2vwv8cx.chr7pe7iynqr.eu-west-1.rds.amazonaws.com
-- Server version:               10.4.13-MariaDB-log - Source distribution
-- Server OS:                    Linux
-- HeidiSQL Version:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for xqpd61r8ts890uk2
CREATE DATABASE IF NOT EXISTS `xqpd61r8ts890uk2` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `xqpd61r8ts890uk2`;

-- Dumping structure for table xqpd61r8ts890uk2.categories
CREATE TABLE IF NOT EXISTS `categories` (
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table xqpd61r8ts890uk2.categories: ~5 rows (approximately)
DELETE FROM `categories`;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` (`category_id`, `name`) VALUES
	(1, 'Arts'),
	(2, 'Social\r\n'),
	(3, 'Culture'),
	(4, 'Sports'),
	(5, 'Music');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;

-- Dumping structure for table xqpd61r8ts890uk2.cities
CREATE TABLE IF NOT EXISTS `cities` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table xqpd61r8ts890uk2.cities: ~5 rows (approximately)
DELETE FROM `cities`;
/*!40000 ALTER TABLE `cities` DISABLE KEYS */;
INSERT INTO `cities` (`id`, `name`) VALUES
	(1, 'Sofia'),
	(2, 'London'),
	(3, 'Madrid'),
	(4, 'Paris'),
	(5, 'Berlin');
/*!40000 ALTER TABLE `cities` ENABLE KEYS */;

-- Dumping structure for table xqpd61r8ts890uk2.events
CREATE TABLE IF NOT EXISTS `events` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` text DEFAULT NULL,
  `city_id` int(11) DEFAULT NULL,
  `photo_url` varchar(200) DEFAULT NULL,
  `happens_on` datetime DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_events_cities` (`city_id`),
  CONSTRAINT `fk_events_cities` FOREIGN KEY (`city_id`) REFERENCES `cities` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table xqpd61r8ts890uk2.events: ~1 rows (approximately)
DELETE FROM `events`;
/*!40000 ALTER TABLE `events` DISABLE KEYS */;
INSERT INTO `events` (`id`, `name`, `description`, `city_id`, `photo_url`, `happens_on`, `created_at`) VALUES
	(1, 'Sed nisi a', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 3, 'https://picsum.photos/id/569/500/500', '2021-04-10 14:15:39', '2021-10-06 14:15:44'),
	(2, 'Art festival', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 1, 'https://picsum.photos/id/263/500/500', '2021-04-01 14:15:39', '2021-01-06 14:15:44'),
	(3, 'Music fest', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 2, 'https://picsum.photos/id/847/500/500', '2021-04-02 14:15:39', '2021-02-06 14:15:44'),
	(4, 'FEST21', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 3, 'https://picsum.photos/id/136/500/500', '2021-04-03 14:15:39', '2021-03-06 14:15:44'),
	(5, 'ART1', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 1, 'https://picsum.photos/id/699/500/500', '2021-04-04 14:15:39', '2021-04-06 14:15:44'),
	(6, 'Lorem Ipsum', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 2, 'https://picsum.photos/id/877/500/500', '2021-04-05 14:15:39', '2021-05-06 14:15:44'),
	(7, 'Dolor sit', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 3, 'https://picsum.photos/id/835/500/500', '2021-04-06 14:15:39', '2021-06-06 14:15:44'),
	(8, 'Sit dolor', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 2, 'https://picsum.photos/id/452/500/500', '2021-04-07 14:15:39', '2021-07-06 14:15:44'),
	(9, 'Lorem dolor', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 2, 'https://picsum.photos/id/305/500/500', '2021-04-08 14:15:39', '2021-08-06 14:15:44'),
	(10, 'DOLOR AMET LOREM', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 1, 'https://picsum.photos/id/988/500/500', '2021-04-09 14:15:39', '2021-09-06 14:15:44');
/*!40000 ALTER TABLE `events` ENABLE KEYS */;

-- Dumping structure for table xqpd61r8ts890uk2.events_categories
CREATE TABLE IF NOT EXISTS `events_categories` (
  `event_id` int(11) DEFAULT NULL,
  `category_id` int(11) DEFAULT NULL,
  UNIQUE KEY `events_categories_pk` (`event_id`,`category_id`),
  KEY `events_categories_categories_fk` (`category_id`),
  CONSTRAINT `events_categories_categories_fk` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`),
  CONSTRAINT `events_categories_events_fk` FOREIGN KEY (`event_id`) REFERENCES `events` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table xqpd61r8ts890uk2.events_categories: ~1 rows (approximately)
DELETE FROM `events_categories`;
/*!40000 ALTER TABLE `events_categories` DISABLE KEYS */;
INSERT INTO `events_categories` (`event_id`, `category_id`) VALUES
	(1, 5),
	(2, 3),
	(5, 3),
	(8, 3);
/*!40000 ALTER TABLE `events_categories` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
