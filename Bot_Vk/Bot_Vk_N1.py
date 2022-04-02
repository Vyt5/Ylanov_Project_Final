import random
import vk_api
#
import bs4 as bs4
import requests
#
from vk_bot import VkBot
from vk_api.longpoll import VkLongPoll, VkEventType

from sys import argv
if len(argv) > 1:
        stroka = argv
        isStroka = True
else:
    stroka = "база билетов пока не загружена"
    isStroka = False


#


def _get_user_name_from_vk_id(self, user_id):
        request = requests.get("https://vk.com/id"+str(user_id))
        bs = bs4.BeautifulSoup(request.text, "html.parser")

        user_name = self._clean_all_tag_from_str(bs.findAll("title")[0])

        return user_name.split()[0]

    
def write_msg(user_id, message):
    vk.method('messages.send', {'user_id': user_id, 'message': message, 'random_id': random.randint(0, 2048)})


# API-ключ созданный ранее
token = "3c314265f4f6993855cb07a25f4d40eec02c38c934aac07aa135fbc1181d0a199fe04c7d9a594c872b8f1"

# Авторизуемся как сообщество
vk = vk_api.VkApi(token=token)

# Работа с сообщениями
longpoll = VkLongPoll(vk)

print("Бот запущен")
# Основной цикл
print("Server started")

if isStroka:
        bot2 =VkBot(286781828)
        write_msg(286781828, bot2.new_message("БИЛЕТЫ"))
        raise SystemExit(1)

for event in longpoll.listen():
    if event.type == VkEventType.MESSAGE_NEW:
        if event.to_me:
        
            print('New message:')
            print(f'For me by: {event.user_id}', end=' ')
            bot = VkBot(event.user_id)
            write_msg(event.user_id, bot.new_message(event.text))
            if event.text == "Пока":
                    raise SystemExit(1)
            if event.user_id != 286781828:
              print(event.user_id)
              write_msg(286781828, f'Мне написал сообщение: {event.user_id}')
              print('Text: ', )
