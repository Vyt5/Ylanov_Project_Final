import bs4 as bs4
import requests

from sys import argv
if len(argv) > 1:
        stroka = argv
        isStroka = True
else:
    stroka = "база билетов пока не загружена"
    isStroka = False

class VkBot:

    def __init__(self, user_id):
        print("\nСоздан объект бота!")

        self._USER_ID = user_id
        self._USERNAME = self._get_user_name_from_vk_id(user_id)
    
#потом дополню список команд
        self._COMMANDS = ["ПРИВЕТ", "ПОГОДА", "ВРЕМЯ", "ПОКА","СПОКОЙНОЙ НОЧИ","СПОКИ-НОКИ","ПОГОДА НА ЗАВТРА","ПОГОДА ЗАВТРА","КАК ДЕЛА?","БИЛЕТЫ"]

#метд получения имени пользователя
    def _get_user_name_from_vk_id(self, user_id):
        request = requests.get("https://vk.com/id"+str(user_id))
        bs = bs4.BeautifulSoup(request.text, "html.parser")

        user_name = self._clean_all_tag_from_str(bs.findAll("title")[0])

        return user_name.split()[0]

    def new_message(self, message):

        # Привет
        if message.upper() == self._COMMANDS[0]:
            return f"Привет-привет, {self._USERNAME}!"

        # Погода
        elif message.upper() == self._COMMANDS[1]:
            return self._get_weather()
        
        #ПОГОДА ЗАВТРА
        elif (message.upper() == self._COMMANDS[6]) or (message.upper() ==self._COMMANDS[7]):
            return self._get_weatherTommorow()

        # Время
        elif message.upper() == self._COMMANDS[2]:
            b5= self._get_time()
            print(b5)
            b6=b5.replace("[", " ")
            b5=b6.replace("]", " ")
            return b5
        # Пока
        elif message.upper() == self._COMMANDS[3]:
            return f"Пока-пока, {self._USERNAME}!"

        
        #КАК ДЕЛА?
        elif message.upper() == self._COMMANDS[8]:
            return f"{self._USERNAME}, всё ЗАМУРРРЧАТЕЛЬНО! А у тебя"

        # Спокойной Ночи
        elif (message.upper() == self._COMMANDS[4]) or (message.upper() ==self._COMMANDS[5]):
            return f"Мрряки-ноки, {self._USERNAME}!"

        elif (message.upper() == self._COMMANDS[9]) or (message.upper() ==self._COMMANDS[9]):
            return stroka

        else:
            return "Мрр-мяу?...Прости, я пока не понимаю тебя"

        

    def _get_time(self):
        request = requests.get("https://time100.ru/Barnaul")
        b = bs4.BeautifulSoup(request.text, "html.parser")
        return self._clean_all_tag_from_str(str(b.find_all('div', class_='time')))
        
    @staticmethod
    def _clean_all_tag_from_str(string_line):

        """
        Очистка строки stringLine от тэгов и их содержимых
        :param string_line: Очищаемая строка
        :return: очищенная строка
        """

        result = ""
        not_skip = True
        for i in list(string_line):
            if not_skip:
                if i == "<":
                    not_skip = False
                else:
                    result += i
            else:
                if i == ">":
                    not_skip = True

        return result

    @staticmethod
    def _get_weather(city: str = "/barnaul") -> list:

        request = requests.get("https://yandex.ru/pogoda" + city +"/details")
        b = bs4.BeautifulSoup(request.text, "html.parser")

        p3 = b.select('.temp__value')
        weather1 = p3[0].getText()
        p4 = b.select('.temp__value')
        weather2 = p4[1].getText()

        w1 = b.select('.weather-table__body-cell_type_condition')
        weatherMorning = w1[0].getText()

        p5 = b.select('.temp__value')
        weather3 = p5[3].getText()
        p6 = b.select('.temp__value')
        weather4 = p6[4].getText()
        p7 = b.select('.temp__value')
        weather5 = p7[6].getText()
        p8 = b.select('.temp__value')
        weather6 = p8[7].getText()

        result = 'Погода в Барнауле\n'
        result = result + ('Утром :' + weather1 + '...' + weather2) + '\n'
        result = result + ('Днём :' + weather3 + '...' + weather4) + '\n'
        result = result + ('Вечером :' + weather5 + '...' + weather6) + '\n'
        result = result + ('Сегодня утром ' + weatherMorning) + '\n'
        #
        print(result)
        #temp = b.select('.rSide .description')
        #weather = temp[0].getText()
        #result = result + weather.strip()

        return result
    
    @staticmethod
    def _get_weatherTommorow(city: str = "/barnaul") -> list:
        
        request = requests.get("https://yandex.ru/pogoda" + city +"/details")
        b = bs4.BeautifulSoup(request.text, "html.parser")

        p9 = b.select('.temp__value')
        weather1 = p9[12].getText()

        w2 = b.select('.weather-table__body-cell_type_condition')
        weatherMorning1 = w2[4].getText()
        
        p10 = b.select('.temp__value')
        weather2 = p10[13].getText()
        p11 = b.select('.temp__value')
        weather3 = p11[15].getText()
        p12 = b.select('.temp__value')
        weather4 = p12[16].getText()
        p13 = b.select('.temp__value')
        weather5 = p13[18].getText()
        p14 = b.select('.temp__value')
        weather6 = p14[19].getText()

        result = 'Погода в Барнауле на завтра\n'
        result = result + ('Утром :' + weather1 + '...' + weather2) + '\n'
        result = result + ('Днём :' + weather3 + '...' + weather4) + '\n'
        result = result + ('Вечером :' + weather5 + '...' + weather6) + '\n'
        result = result + ('Утром будет ' + weatherMorning1) + '\n'
        #
        print(result)
        #temp = b.select('.rSide .description')
        #weather = temp[0].getText()
        #result = result + weather.strip()

        return result

