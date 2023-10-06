-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 06-Out-2023 às 17:03
-- Versão do servidor: 8.0.31
-- versão do PHP: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `escola`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `aluno`
--

DROP TABLE IF EXISTS `aluno`;
CREATE TABLE IF NOT EXISTS `aluno` (
  `RA` varchar(10) NOT NULL,
  `Nome` varchar(30) NOT NULL,
  `CPF` varchar(14) NOT NULL,
  `Endereco` varchar(30) NOT NULL,
  `Telefone` varchar(13) NOT NULL,
  `Email` varchar(30) NOT NULL,
  `Curso` varchar(30) NOT NULL,
  `NotaBim1` float NOT NULL,
  `NotaBim2` float NOT NULL,
  `NotaBim3` float NOT NULL,
  `NotaBim4` float NOT NULL,
  `Media` float NOT NULL,
  PRIMARY KEY (`RA`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Extraindo dados da tabela `aluno`
--

INSERT INTO `aluno` (`RA`, `Nome`, `CPF`, `Endereco`, `Telefone`, `Email`, `Curso`, `NotaBim1`, `NotaBim2`, `NotaBim3`, `NotaBim4`, `Media`) VALUES
('2', 'ze ruela', '223.456.789-10', 'bbbbbbbb', '11111-1112', '2test@gmail.com', 'Informatica', 7, 8, 7, 8, 7),
('1', 'gabriel', '123.456.789-10', 'aaaaaaaaa', '11111-1111', '1test@gmail.com', 'Informatica', 7, 8, 7, 8, 7),
('3', 'Tio daEsquina', '323.456.789-10', 'ccccccccccccc', '11111-1113', '3test@gmail.com', 'Informatica', 7, 8, 7, 8, 7);

-- --------------------------------------------------------

--
-- Estrutura da tabela `curso`
--

DROP TABLE IF EXISTS `curso`;
CREATE TABLE IF NOT EXISTS `curso` (
  `Codigo` varchar(10) NOT NULL,
  `Nome` varchar(30) NOT NULL,
  `CargaHoraria` varchar(10) NOT NULL,
  `Periodo` varchar(15) NOT NULL,
  PRIMARY KEY (`Codigo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Extraindo dados da tabela `curso`
--

INSERT INTO `curso` (`Codigo`, `Nome`, `CargaHoraria`, `Periodo`) VALUES
('1', 'Trafico de placa de video', '330', 'integral'),
('2', 'Empreendedorismo de pobre', '20', 'manha'),
('3', 'Informatica dos Cria', '3300', 'integral');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
