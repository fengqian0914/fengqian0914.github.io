-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2024-06-10 15:35:35
-- 伺服器版本： 10.4.22-MariaDB
-- PHP 版本： 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫: `order_phps`
--
CREATE DATABASE IF NOT EXISTS `order_phps` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `order_phps`;

-- --------------------------------------------------------

--
-- 資料表結構 `付款資訊`
--

CREATE TABLE `付款資訊` (
  `付款編號` varchar(20) CHARACTER SET utf8 NOT NULL,
  `付款方式` varchar(100) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `付款資訊`
--

INSERT INTO `付款資訊` (`付款編號`, `付款方式`) VALUES
('pay_1', '現金'),
('pay_10', '行動支付'),
('pay_11', '信用卡/金融卡'),
('pay_12', '現金'),
('pay_13', '現金'),
('pay_14', '現金'),
('pay_2', '現金'),
('pay_3', '現金'),
('pay_4', '信用卡/金融卡'),
('pay_5', '行動支付'),
('pay_6', '信用卡/金融卡'),
('pay_7', '信用卡/金融卡'),
('pay_8', '信用卡/金融卡'),
('pay_9', '信用卡/金融卡');

-- --------------------------------------------------------

--
-- 資料表結構 `團購`
--

CREATE TABLE `團購` (
  `團購編號` varchar(20) CHARACTER SET utf8 NOT NULL,
  `建立者帳號` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `開啟時間` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `團購`
--

INSERT INTO `團購` (`團購編號`, `建立者帳號`, `開啟時間`) VALUES
('GroupBuy_1', NULL, '2024-06-04 16:22:05'),
('GroupBuy_10', NULL, '2024-06-07 21:56:05'),
('GroupBuy_11', NULL, '2024-06-07 22:00:51'),
('GroupBuy_12', NULL, '2024-06-08 23:23:12'),
('GroupBuy_13', NULL, '2024-06-09 19:27:01'),
('GroupBuy_14', NULL, '2024-06-09 21:17:22'),
('GroupBuy_2', NULL, '2024-06-04 16:26:12'),
('GroupBuy_3', NULL, '2024-06-04 16:31:51'),
('GroupBuy_4', NULL, '2024-06-04 18:32:29'),
('GroupBuy_5', NULL, '2024-06-04 18:35:08'),
('GroupBuy_6', NULL, '2024-06-07 20:48:41'),
('GroupBuy_7', NULL, '2024-06-07 20:48:44'),
('GroupBuy_8', NULL, '2024-06-07 21:47:08'),
('GroupBuy_9', NULL, '2024-06-07 21:54:58');

-- --------------------------------------------------------

--
-- 資料表結構 `店家列表`
--

CREATE TABLE `店家列表` (
  `店家編號` varchar(20) CHARACTER SET utf8 NOT NULL,
  `電話` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `地址` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `類別編號` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `店家名稱` varchar(50) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `店家列表`
--

INSERT INTO `店家列表` (`店家編號`, `電話`, `地址`, `類別編號`, `店家名稱`) VALUES
('Store_1', '02-2250-5065', '新北市板橋區文化路二段173號', 'Store_type_1', '麥當勞'),
('Store_10', '02-2262-6698', '新北市土城區延和路110號', 'Store_type_6', '孫東寶'),
('Store_11', '02-2951-4655', '新北市板橋區忠孝路167號', 'Store_type_9', '拿坡里披薩'),
('Store_12', '02-8251-3892', '新北市板橋區文化路一段302號', 'Store_type_1', '摩斯漢堡'),
('Store_13', '02-2958-9133', '新北市板橋區中山路一段152號13樓', 'Store_type_8', '瓦城'),
('Store_14', '02-2221-6389', '新北市中和區中山路三段122號B2', 'Store_type_8', '大心'),
('Store_15', '02-2958-1008', '新北市板橋區中山路二段168號', 'Store_type_1', '漢堡王'),
('Store_2', '02-2256-5226', '新北市板橋區雙十路二段170號', 'Store_type_1', '肯德基'),
('Store_3', '02-2758-3868', '台北市信義區松仁路97號', 'Store_type_2', '一蘭拉麵'),
('Store_4', '02-2321-8928', '台北市信義路二段194號', 'Store_type_4', '鼎泰豐'),
('Store_5', '02-2960-1199', '新北市板橋區縣民大道二段7號2樓', 'Store_type_5', '涓豆腐'),
('Store_6', '02-2955-2125', '新北市板橋區信義路16-4號', 'Store_type_5', '起家雞'),
('Store_7', '02-77230887', '新北市板橋區文化路一段437-3號2樓', 'Store_type_5', '兩餐'),
('Store_8', '02-8273-2606', '新北市土城區青雲路152號1樓', 'Store_type_3', '石二鍋'),
('Store_9', '02-8231-6097', '新北市永和區中山路一段238號B2', 'Store_type_2', '花月嵐');

-- --------------------------------------------------------

--
-- 資料表結構 `店家類型`
--

CREATE TABLE `店家類型` (
  `類別編號` varchar(20) CHARACTER SET utf8 NOT NULL,
  `類別名稱` varchar(100) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `店家類型`
--

INSERT INTO `店家類型` (`類別編號`, `類別名稱`) VALUES
('Store_type_1', '速食店'),
('Store_type_10', '西洋料理'),
('Store_type_11', '烤肉店'),
('Store_type_2', '日式料理'),
('Store_type_3', '火鍋'),
('Store_type_4', '中式料理'),
('Store_type_5', '韓式料理'),
('Store_type_6', '牛排'),
('Store_type_7', '小火鍋'),
('Store_type_8', '泰式料理'),
('Store_type_9', '披薩');

-- --------------------------------------------------------

--
-- 資料表結構 `會員列表`
--

CREATE TABLE `會員列表` (
  `會員帳號` varchar(40) CHARACTER SET utf8 NOT NULL,
  `姓名` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `電話` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `EMAIL` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `密碼` varchar(255) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `會員列表`
--

INSERT INTO `會員列表` (`會員帳號`, `姓名`, `電話`, `EMAIL`, `密碼`) VALUES
('1', '1', '1', '11@a.a', '11'),
('a98765', 'cccaaa', '123456', '1@a.a', '15'),
('chan', '徐逢謙', '0912345678', 'chan@gmail.com', 'asd123'),
('chan914', '謙', '0912345678', 'jas@ld.com', '1234');

-- --------------------------------------------------------

--
-- 資料表結構 `訂單小計`
--

CREATE TABLE `訂單小計` (
  `訂單編號` varchar(20) CHARACTER SET utf8 NOT NULL,
  `餐點編號` varchar(20) CHARACTER SET utf8 NOT NULL,
  `數量` int(11) DEFAULT NULL,
  `小計` decimal(10,2) DEFAULT NULL,
  `訂購者` varchar(255) DEFAULT NULL,
  `店家編號` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `訂單小計`
--

INSERT INTO `訂單小計` (`訂單編號`, `餐點編號`, `數量`, `小計`, `訂購者`, `店家編號`) VALUES
('Order_1', 'Meal_1', 1, '310.00', '王小名', 'Store_3'),
('Order_10', 'Meal_1', 2, '1198.00', '白美美', 'Store_6'),
('Order_10', 'Meal_2', 7, '4333.00', '白美美', 'Store_6'),
('Order_10', 'Meal_3', 3, '1707.00', '白美美', 'Store_6'),
('Order_11', 'Meal_1', 1, '250.00', '黑漆漆', 'Store_4'),
('Order_11', 'Meal_2', 3, '480.00', '黑漆漆', 'Store_4'),
('Order_11', 'Meal_3', 4, '960.00', '黑漆漆', 'Store_4'),
('Order_12', 'Meal_1', 1, '617.00', 'chan', 'Store_2'),
('Order_13', 'Meal_2', 1, '160.00', '林小美', 'Store_4'),
('Order_14', 'Meal_1', 1, '190.00', '徐逢謙', 'Store_10'),
('Order_14', 'Meal_2', 6, '2100.00', '徐逢謙', 'Store_10'),
('Order_2', 'Meal_1', 1, '200.00', '林大同', 'Store_2'),
('Order_3', 'Meal_2', 3, '144.00', '陳小美', 'Store_1'),
('Order_3', 'Meal_3', 4, '356.00', '陳小美', 'Store_1'),
('Order_3', 'Meal_5', 6, '396.00', '陳小美', 'Store_1'),
('Order_4', 'Meal_3', 6, '534.00', '張小路', 'Store_1'),
('Order_5', 'Meal_1', 1, '200.00', '李大帥', 'Store_2'),
('Order_6', 'Meal_1', 1, '328.00', '陳小美', 'Store_5'),
('Order_6', 'Meal_3', 1, '348.00', '陳小美', 'Store_5'),
('Order_7', 'Meal_1', 1, '328.00', '陳小美', 'Store_5'),
('Order_7', 'Meal_3', 1, '348.00', '陳小美', 'Store_5'),
('Order_8', 'Meal_1', 1, '310.00', '張曉美', 'Store_3'),
('Order_9', 'Meal_1', 1, '349.00', '黃咚咚', 'Store_7');

-- --------------------------------------------------------

--
-- 資料表結構 `訂單總價`
--

CREATE TABLE `訂單總價` (
  `訂單編號` varchar(20) CHARACTER SET utf8 NOT NULL,
  `會員帳號` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `付款編號` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `訂單時間` datetime DEFAULT NULL,
  `取餐位置` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `總價` decimal(10,2) DEFAULT NULL,
  `取單時間` datetime DEFAULT NULL,
  `團購編號` varchar(20) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `訂單總價`
--

INSERT INTO `訂單總價` (`訂單編號`, `會員帳號`, `付款編號`, `訂單時間`, `取餐位置`, `總價`, `取單時間`, `團購編號`) VALUES
('Order_1', 'a98765', 'pay_1', '2024-06-04 16:22:05', '新北市板橋區文化路一段313號', '310.00', '2024-06-04 16:52:05', 'GroupBuy_1'),
('Order_10', 'a98765', 'pay_10', '2024-06-07 21:56:05', '台北市中正區重慶南路一段122號', '7238.00', '2024-06-07 22:26:05', 'GroupBuy_10'),
('Order_11', 'a98765', 'pay_11', '2024-06-07 22:00:51', '台北市中正區重慶南路一段122號', '1690.00', '2024-06-07 22:30:51', 'GroupBuy_11'),
('Order_12', 'a98765', 'pay_12', '2024-06-08 23:23:12', '新北市新莊區', '617.00', '2024-06-08 23:53:12', 'GroupBuy_12'),
('Order_13', 'a98765', 'pay_13', '2024-06-09 19:27:01', '新北市蘆洲區', '160.00', '2024-06-09 19:57:01', 'GroupBuy_13'),
('Order_14', 'chan', 'pay_14', '2024-06-09 21:17:22', '新北市板橋區OO路', '2290.00', '2024-06-09 21:47:22', 'GroupBuy_14'),
('Order_2', 'a98765', 'pay_2', '2024-06-04 16:26:12', '新北市板橋區文化路一段313號', '200.00', '2024-06-04 16:56:12', 'GroupBuy_2'),
('Order_3', 'a98765', 'pay_3', '2024-06-04 16:31:51', '新北市板橋區文化路一段313號', '896.00', '2024-06-04 17:01:51', 'GroupBuy_3'),
('Order_4', 'chan914', 'pay_4', '2024-06-04 18:32:29', '新北市板橋區文化路一段313號', '534.00', '2024-06-04 19:02:29', 'GroupBuy_4'),
('Order_5', 'chan914', 'pay_5', '2024-06-04 18:35:08', '新北市板橋區文化路一段313號', '200.00', '2024-06-04 19:05:08', 'GroupBuy_5'),
('Order_6', 'a98765', 'pay_6', '2024-06-07 20:48:41', '新北市板橋區文化路一段313號', '676.00', '2024-06-07 21:18:41', 'GroupBuy_6'),
('Order_7', 'a98765', 'pay_7', '2024-06-07 20:48:44', '新北市板橋區文化路一段313號', '676.00', '2024-06-07 21:18:44', 'GroupBuy_7'),
('Order_8', 'a98765', 'pay_8', '2024-06-07 21:47:08', '台北市中正區重慶南路一段122號', '310.00', '2024-06-07 22:17:08', 'GroupBuy_8'),
('Order_9', 'a98765', 'pay_9', '2024-06-07 21:54:58', '台北市中正區重慶南路一段122號', '349.00', '2024-06-07 22:24:58', 'GroupBuy_9');

-- --------------------------------------------------------

--
-- 資料表結構 `餐點`
--

CREATE TABLE `餐點` (
  `餐點編號` varchar(20) CHARACTER SET utf8 NOT NULL,
  `餐點名稱` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `單價` decimal(10,2) DEFAULT NULL,
  `說明` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `餐點類型編號` varchar(20) CHARACTER SET utf8 NOT NULL,
  `店家編號` varchar(20) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `餐點`
--

INSERT INTO `餐點` (`餐點編號`, `餐點名稱`, `單價`, `說明`, `餐點類型編號`, `店家編號`) VALUES
('Meal_1', '大麥克', '80.00', '麥當勞永遠的一號餐， 全球狂熱50年， 紐澳100%雙層純牛肉， 淋上大麥克招牌醬料， 加上生菜、吉事、洋蔥、酸黃瓜， 美味層層堆疊，口感樂趣無窮。 從美國總統到素人都是鐵粉， 經濟學家還發明「大麥克指數」致敬，果然，只有大麥克，才是大麥克！', 'Meal_type_1', 'Store_1'),
('Meal_1', '主廚牛排', '190.00', '4 盎司/澳洲/巴拉圭/紐西蘭/美國  油脂分佈均勻，香甜多汁，肉質軟嫩彈口帶有嚼勁，小資份量無負擔。', 'Meal_type_9', 'Store_10'),
('Meal_1', '西西里燻雞披薩', '369.00', '散發濃郁香氣的煙燻雞肉加上蘑菇的鮮嫩口感，富嚼勁的餅皮，佐以特製番茄醬，讓你享受道地的義式風味！', 'Meal_type_13', 'Store_11'),
('Meal_1', '摩斯吉士漢堡套餐', '175.00', '摩斯獨創的肉汁醬搭配多項蔬果組合，與香濃的吉士片，讓您品嘗5度C到75度C的好味道。', 'Meal_type_1', 'Store_12'),
('Meal_1', '月亮蝦餅', '370.00', '每份月亮都經過108 道用心料理步驟，真材實料、口口酥脆鮮美，一直是瓦城銷售排行第一名！', 'Meal_type_3', 'Store_13'),
('Meal_1', '酸辣海鮮麵', '280.00', '以泰國南薑、香茅、檸檬等多種香料熬煮，加新鮮蝦子與豬肉片，最不容易錯過的獨家招牌！', 'Meal_type_12', 'Store_14'),
('Meal_1', '華堡餐', '179.00', '選用100%澳洲純牛肉，採高溫火烤，保留肉汁原味，搭配口感紮實的5吋漢堡，加入新鮮蔬菜，讓你每一口咬下都吃得到牛肉的火烤美味！', 'Meal_type_1', 'Store_15'),
('Meal_1', '宅宅快樂餐', '617.00', '咔啦脆雞(辣)X8\r\n原味蛋撻x6\r\n香酥脆薯(中)X2\r\n百事可樂(小)X4', 'Meal_type_3', 'Store_2'),
('Meal_1', '天然豚骨拉麵', '310.00', '把豚骨獨有的腥味完全去除，烹調出極致美味的天然豚骨湯。\r\n加入以湯的配搭作為首要考慮，混合多種特選小麥粉所製作的一蘭特製生麵後 ，為了使味道變得更有層次，再加入以唐辛子為基礎，混合30多種配料與辛香料，經過無數晝夜熬煮而成的「赤紅秘製醬汁」，美味的天然豚骨湯拉麵就此完成。', 'Meal_type_2', 'Store_3'),
('Meal_1', '蝦肉紅油抄手', '250.00', '特選上等鮮蝦輔以細切豬肉餡，包裹在薄透Q滑的麵皮中，淋上特製紅油醬汁，鮮辣濃香令人回味無窮！', 'Meal_type_4', 'Store_4'),
('Meal_1', '嫩豆腐煲', '328.00', '「嫩豆腐煲」的豆腐使用生機豆腐創造獨有的綿密口感和韓國傳統石鍋飯所搭配的美味料理', 'Meal_type_6', 'Store_5'),
('Meal_1', '招牌洋釀', '599.00', '最道地的韓式風味，香甜不膩口！', 'Meal_type_3', 'Store_6'),
('Meal_1', '年糕鍋', '349.00', '以辣炒年糕、魚板、獨特炸物及道地泡麵等等，搭配韓國傳統的獨特性醬料，將各種食材串連出美好的口味。', 'Meal_type_10', 'Store_7'),
('Meal_1', '剝皮辣椒鍋', '287.00', '選用優質氣冷雞肉，剝皮辣椒辛香微辣，雞湯鹹中帶甜，雞肉與湯頭完美組合讓人欲罷不能。', 'Meal_type_10', 'Store_8'),
('Meal_1', '大蒜拳骨拉麵', '198.00', '人氣NO.1 使用拳骨、上選大蒜熬煮出獨特而濃厚的秘傳湯頭。 拳骨指的是豬的腿關節骨，形狀像拳頭，熬煮後湯頭富含膠質而鮮甜， 再放入一勺獨門蒜醬，層次提升好滋味！', 'Meal_type_2', 'Store_9'),
('Meal_2', '豬肉滿福堡', '48.00', '美味的豬肉滿福堡，讓您享受滿滿的幸福感！', 'Meal_type_1', 'Store_1'),
('Meal_2', '紐約教父牛排', '350.00', '8 盎司 /澳洲  採用澳洲穀飼牛，不經調味，原味呈現，肉質香甜，口感Ｑ彈結實', 'Meal_type_9', 'Store_10'),
('Meal_2', '義式炸雞超值桶', '299.00', '上等雞肉、家傳按摩、定溫油炸、現點現炸、獨特炸雞粉 *品項依門市搭配為準', 'Meal_type_3', 'Store_11'),
('Meal_2', '超級大麥薑燒珍珠堡套餐', '175.00', '香Q美味的大麥米飯，搭配現炒薑味醃製豬肉片與青生菜。', 'Meal_type_1', 'Store_12'),
('Meal_2', '酸辣海鮮湯', '365.00', '這道泰國國寶湯，酸中帶辣、辣中帶著鮮甜，美味程度列名為世界三大名湯！', 'Meal_type_11', 'Store_13'),
('Meal_2', '咖哩雞腿麵', '230.00', '黃咖哩與蔬菜熬煮濃郁湯頭，搭配軟嫩雞腿，一上桌就誘人食慾。', 'Meal_type_2', 'Store_14'),
('Meal_2', '花生安格斯牛肉堡套餐', '190.00', '濃郁顆粒花生醬遇上火烤安格斯牛肉排，再淋上絲滑起司、疊上培根。多層次口感的花生醬漢堡，一口咬下超過癮！', 'Meal_type_1', 'Store_15'),
('Meal_2', '吮指雙雞絕配餐', '189.00', '咔啦脆雞x2 香酥脆薯(小)x1 百事可樂(中)x1 原味蛋撻x1', 'Meal_type_3', 'Store_2'),
('Meal_2', '排骨蛋炒飯', '160.00', '採用優質台梗九號米的金黃色澤炒飯，蛋花均勻密布，每口咀嚼皆富含蛋香與蔥香，再搭配肉香十足的鼎泰豐炸排骨，令人食慾大開。', 'Meal_type_5', 'Store_4'),
('Meal_2', '海鮮辣炒年糕', '368.00', '韓式年糕搭配魚板、蝦子與魷魚，這份餐點的辣度稍強，紅通通的配色讓愛吃辣的我大呼過癮', 'Meal_type_7', 'Store_5'),
('Meal_2', '黃金頂級起司', '619.00', '滿滿黃金起司粉，鹹甜濃郁、香氣十足！', 'Meal_type_3', 'Store_6'),
('Meal_2', '經典爆香石頭鍋', '248.00', '石頭鍋加入了濃縮雞湯精華和日本道地柴魚汁的熬煮，使湯頭鮮甜可口，令人垂涎欲滴。', 'Meal_type_10', 'Store_8'),
('Meal_2', '黃金味噌拉麵', '250.00', '白味噌加入研磨芝麻提味，濃郁湯汁搭配特製粗麵一起入口，一滴不剩完食吧!', 'Meal_type_2', 'Store_9'),
('Meal_3', '四盎司牛肉堡', '89.00', '四盎司的純牛肉堡，鮮嫩多汁，滿足您對美味的渴望！', 'Meal_type_1', 'Store_1'),
('Meal_3', '帶骨牛小排', '310.00', '帶骨牛小排是取自牛隻胸肋骨第六至第八根肋骨帶骨牛肉，煎至全熟後，香味四溢，肉質香甜，油筋適中，多汁耐嚼，同時享受筋與肉的兩種美味。', 'Meal_type_9', 'Store_10'),
('Meal_3', '咔滋雞腿桶', '329.00', '嚴選鮮嫩雞腿，以獨有的按壓技術現裹上層層交疊的粉漿，即時下鍋酥炸，瞬間鎖住雞汁精華，內嫩外酥的義式風味，拿坡里咔滋雞腿讓您體驗從咔滋到噴汁的交響口感!', 'Meal_type_3', 'Store_11'),
('Meal_3', '摩斯炸蝦堡套餐', '180.00', '使用新鮮美味、脆口彈牙的白蝦以特定比例的裹粉製成的炸蝦帕隄，油炸後，外層酥脆、內層鮮甜飽滿，搭配風味清爽的塔塔醬、豐富生菜，整體口感Ｑ彈豐富，滋味爽口。', 'Meal_type_1', 'Store_12'),
('Meal_3', '泰式炒河粉', '260.00', '熱炒到噴香又軟嫩Q彈的泰式河粉，豐盛均衡好滿足～', 'Meal_type_12', 'Store_13'),
('Meal_3', '清燉越南牛肉河粉', '280.00', '豪邁使用牛骨、蔬菜、香料熬出鮮甜湯頭，搭配板腱牛肉片與牛肉丸，執著用心的好味道~ ', 'Meal_type_12', 'Store_14'),
('Meal_3', '重磅培根雙層牛肉堡套餐', '264.00', '濃郁起司、搭配加量酥炸培根，嚴選重磅100%澳洲純牛肉，高溫火烤，完美鎖住肉汁原味，大口咬下肉香四溢。', 'Meal_type_1', 'Store_15'),
('Meal_3', '義式香草紙包雞絕配餐', '180.00', '義式香草紙包雞X1 雞汁風味飯x1 百事可樂(中)x1', 'Meal_type_9', 'Store_2'),
('Meal_3', '紅燒牛肉湯', '240.00', '獨門秘方滷製，嚐得到牛筋Q軟口感，以及鮮嫰牛肉的美妙滋味，搭配精心熬製的牛骨湯頭，自然馨香，嚐來格外甘美。', 'Meal_type_11', 'Store_4'),
('Meal_3', '泡菜豆腐煎餅', '348.00', '微辣泡菜和細嫩豆腐塊，加入些許豬肉末，煎的香酥脆口讓人讚不絕口！', 'Meal_type_8', 'Store_5'),
('Meal_3', '經典原味', '569.00', '薄脆外皮，軟嫩多汁', 'Meal_type_3', 'Store_6'),
('Meal_3', '涮涮鍋', '198.00', '蒜與辛香料的結合讓顧客一再回訪的經典口味', 'Meal_type_10', 'Store_8'),
('Meal_3', '銀次郎魚豚骨拉麵', '250.00', '特製豚骨和魚介的絕妙搭配，並於湯中加入洋蔥丁增加口感，叉燒表面再撒上些許鰹魚粉，濃郁鮮甜且香味十足。', 'Meal_type_2', 'Store_9'),
('Meal_4', '麥克鷄塊(6塊)', '69.00', '麥當勞的經典小食，外酥內嫩的鷄塊，一口咬下滿滿的幸福感！', 'Meal_type_3', 'Store_1'),
('Meal_4', '摩摩喳喳', '120.00', '西米露、綠豆沙、亞達枳、菠蘿蜜、紅毛丹、石榴紅寶石等豐富材料， 淋上香氣出眾的七葉蘭糖汁及椰奶，瓦城超人氣招牌甜點。', 'Meal_type_11', 'Store_13'),
('Meal_4', '花生熔岩咔啦雞腿堡 絕配餐', '179.00', '花生熔岩咔啦雞腿堡(辣)X1 香酥脆薯(中)X1 百事可樂(中)X1', 'Meal_type_1', 'Store_2'),
('Meal_4', '蝦仁絲瓜小籠包', '340.00', '精選在地清甜的角瓜及絲瓜，與美味彈牙的蝦仁，配成完美比例，白透麵皮依稀透出翠綠的色澤，顯得格外誘人。', 'Meal_type_12', 'Store_4'),
('Meal_4', '竹下食堂醬油拉麵', '210.00', '醬油高湯與雞骨高湯融合，清澄高湯帶點醬油鮮鹹香氣， 經典配料加以點綴，令人懷念的醬油拉麵登場！', 'Meal_type_2', 'Store_9'),
('Meal_5', '薯條(大)', '66.00', '麥當勞的招牌薯條，炸得金黃酥脆，外脆內軟，一口咬下滿足您的味蕾！', 'Meal_type_3', 'Store_1'),
('Meal_5', '芝麻大包', '80.00', '精選頂級黑芝麻，經過細膩的料理手法，讓濃郁香醇的芝麻原味，在口中久久不散。', 'Meal_type_12', 'Store_4'),
('Meal_5', '藤崎家拉麵', '250.00', '由日本花月嵐拉麵職人「藤崎先生」研發!在香醇豚骨醬油湯頭中，表面浮著溫和淡雅的黃澄雞油，端上桌時，濃郁香氣撲鼻而來，令人忍不住先品嚐一口醇美湯頭。', 'Meal_type_2', 'Store_9'),
('Meal_6', '勁辣鷄腿堡', '80.00', '辣味十足的勁辣鷄腿堡，鷄腿肉嫩滑多汁，讓您一口咬下就愛上它！', 'Meal_type_1', 'Store_1');

-- --------------------------------------------------------

--
-- 資料表結構 `餐點類型`
--

CREATE TABLE `餐點類型` (
  `類別編號` varchar(20) CHARACTER SET utf8 NOT NULL,
  `類別名稱` varchar(100) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `餐點類型`
--

INSERT INTO `餐點類型` (`類別編號`, `類別名稱`) VALUES
('Meal_type_1', '漢堡'),
('Meal_type_10', '鍋類'),
('Meal_type_11', '湯類/飲品'),
('Meal_type_12', '麵食'),
('Meal_type_13', '披薩'),
('Meal_type_2', '麵類'),
('Meal_type_3', '炸物'),
('Meal_type_4', '餃子'),
('Meal_type_5', '飯類'),
('Meal_type_6', '煲類'),
('Meal_type_7', '糕類'),
('Meal_type_8', '餅類'),
('Meal_type_9', '肉類');

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `付款資訊`
--
ALTER TABLE `付款資訊`
  ADD PRIMARY KEY (`付款編號`);

--
-- 資料表索引 `團購`
--
ALTER TABLE `團購`
  ADD PRIMARY KEY (`團購編號`),
  ADD KEY `FK_團購_會員列表` (`建立者帳號`);

--
-- 資料表索引 `店家列表`
--
ALTER TABLE `店家列表`
  ADD PRIMARY KEY (`店家編號`),
  ADD KEY `FK_店家列表_店家類型` (`類別編號`);

--
-- 資料表索引 `店家類型`
--
ALTER TABLE `店家類型`
  ADD PRIMARY KEY (`類別編號`);

--
-- 資料表索引 `會員列表`
--
ALTER TABLE `會員列表`
  ADD PRIMARY KEY (`會員帳號`);

--
-- 資料表索引 `訂單小計`
--
ALTER TABLE `訂單小計`
  ADD PRIMARY KEY (`訂單編號`,`餐點編號`);

--
-- 資料表索引 `訂單總價`
--
ALTER TABLE `訂單總價`
  ADD PRIMARY KEY (`訂單編號`),
  ADD KEY `FK_訂單總價_會員列表` (`會員帳號`),
  ADD KEY `FK_訂單總價_付款資訊` (`付款編號`),
  ADD KEY `FK_訂單總價_團購` (`團購編號`);

--
-- 資料表索引 `餐點`
--
ALTER TABLE `餐點`
  ADD PRIMARY KEY (`餐點編號`,`店家編號`),
  ADD KEY `idx_餐點類型編號` (`餐點類型編號`),
  ADD KEY `idx_店家編號` (`店家編號`);

--
-- 資料表索引 `餐點類型`
--
ALTER TABLE `餐點類型`
  ADD PRIMARY KEY (`類別編號`);

--
-- 已傾印資料表的限制式
--

--
-- 資料表的限制式 `團購`
--
ALTER TABLE `團購`
  ADD CONSTRAINT `FK_團購_會員列表` FOREIGN KEY (`建立者帳號`) REFERENCES `會員列表` (`會員帳號`);

--
-- 資料表的限制式 `店家列表`
--
ALTER TABLE `店家列表`
  ADD CONSTRAINT `FK_店家列表_店家類型` FOREIGN KEY (`類別編號`) REFERENCES `店家類型` (`類別編號`);

--
-- 資料表的限制式 `訂單小計`
--
ALTER TABLE `訂單小計`
  ADD CONSTRAINT `FK_訂單小計_餐點` FOREIGN KEY (`餐點編號`) REFERENCES `餐點` (`餐點編號`);

--
-- 資料表的限制式 `訂單總價`
--
ALTER TABLE `訂單總價`
  ADD CONSTRAINT `FK_訂單總價_付款資訊` FOREIGN KEY (`付款編號`) REFERENCES `付款資訊` (`付款編號`),
  ADD CONSTRAINT `FK_訂單總價_團購` FOREIGN KEY (`團購編號`) REFERENCES `團購` (`團購編號`),
  ADD CONSTRAINT `FK_訂單總價_會員列表` FOREIGN KEY (`會員帳號`) REFERENCES `會員列表` (`會員帳號`);

--
-- 資料表的限制式 `餐點`
--
ALTER TABLE `餐點`
  ADD CONSTRAINT `FK_餐點_店家列表` FOREIGN KEY (`店家編號`) REFERENCES `店家列表` (`店家編號`),
  ADD CONSTRAINT `FK_餐點_餐點類型` FOREIGN KEY (`餐點類型編號`) REFERENCES `餐點類型` (`類別編號`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
