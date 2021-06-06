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

-- Dumping data for table xqpd61r8ts890uk2.categories: ~0 rows (approximately)
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
REPLACE INTO `categories` (`category_id`, `name`) VALUES
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
/*!40000 ALTER TABLE `cities` DISABLE KEYS */;
REPLACE INTO `cities` (`id`, `name`) VALUES
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

-- Dumping data for table xqpd61r8ts890uk2.events: ~0 rows (approximately)
/*!40000 ALTER TABLE `events` DISABLE KEYS */;
REPLACE INTO `events` (`id`, `name`, `description`, `city_id`, `photo_url`, `happens_on`, `created_at`) VALUES
	(1, 'Art festival', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis nisi a pulvinar.', 1, 'https://randomwordgenerator.com/img/picture-generator/54e7d54b4a56ab14f1dc8460962e33791c3ad6e04e5074417d2c7ed19244c0_640.jpg', '2021-04-06 14:15:39', '2021-04-06 14:15:44');
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

-- Dumping data for table xqpd61r8ts890uk2.events_categories: ~0 rows (approximately)
/*!40000 ALTER TABLE `events_categories` DISABLE KEYS */;
REPLACE INTO `events_categories` (`event_id`, `category_id`) VALUES
	(1, 3);
/*!40000 ALTER TABLE `events_categories` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
