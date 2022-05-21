using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Diagnostics; // позволяет нам создать журнал отладки в окне вывода

namespace BjiakeWar
{
    public partial class Form1 : Form
    {
        List<Button> playerPosition; // создайте список для всех кнопок положения игрока
        List<Button> enemyPosition; // создайте список для всех кнопок вражеской позиции
        Random rand = new Random(); // создайте новый экземпляр для случайного класса с именем rand
        int totalShips = 3; // общее количество кораблей игрока
        int totalenemy = 3; // общее количество вражеских кораблей
        int rounds = 10; // всего раундов, каждый из которых сыграет по 5 раундов
        int playerTotalScore = 0; // счет игрока по умолчанию
        int enemyTotalScore = 0; // счет противника по умолчанию
        public Form1()
        {
            InitializeComponent();
            loadbuttons(); // загрузите кнопки для врага и игрока в систему
            attackButton.Enabled = false; // отключить кнопку атаки игрока
            enemyLocationList.Text = null; // обнулить выпадающий список местоположения врага
        }
        private void loadbuttons()
        {
            // эта функция загрузит все кнопки в списки, которые мы объявили выше
            // сначала мы загружаем все кнопки игрока и врага
            playerPosition = new List<Button> { w1, w2, w3, w4, x1, x2, x3, x4, y1, y2, y3, y4, z1, z2, z3, z4 };
            enemyPosition = new List<Button> { a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4 };

            // этот цикл будет проходить через каждую кнопку вражеской позиции
            // затем он добавит их в выпадающий список местоположения врага для нас
            // это также удалит все метки с кнопок расположения врага
            for (int i = 0; i < enemyPosition.Count; i++)
            {
                enemyPosition[i].Tag = null;
                enemyLocationList.Items.Add(enemyPosition[i].Text);
            }
        }

        private void playerPicksPosition(object sender, EventArgs e)
        {
            // эта функция позволит игроку выбрать 3 позиции на карте
            // в начале игры именно так мы позволяем игроку выбрать 3 позиции

            if (totalShips > 0)
            {
                // если общее количество кораблей больше 0, то мы проверяем
                var button = (Button)sender;
                // какая кнопка была нажата
                button.Enabled = false;
                // отключить эту кнопку
                button.Tag = "playerShip";
                // прикрепите к нему тег под названием playership
                button.BackColor = System.Drawing.Color.Blue;
                // изменить цвет на синий
                totalShips--;
                // уменьшите общее количество кораблей на 1
            }
            if (totalShips == 0)
            {
                // если игрок выбрал все свои 3 корабля 
                // затем мы делаем следующее
                attackButton.Enabled = true;
                // активировать кнопку атаки
                attackButton.BackColor = System.Drawing.Color.Red;
                // придайте ему фоновый цвет красного цвета
                helpText.Top = 55;
                // переместить текст справки в начало 55
                helpText.Left = 230;
                // переместить текст справки влево 230
                helpText.Text = "2) Теперь выберите позицию атаки из выпадающего списка";

            }
        }

        private void attackEnemyPosition(object sender, EventArgs e)
        {

        }

        private void enemyPicksPosition(object sender, EventArgs e)
        {

        }
    }
}
