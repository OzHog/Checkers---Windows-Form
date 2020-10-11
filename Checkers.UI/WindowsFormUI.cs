using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ex05.Checkers.GameLogic;
using Ex05.Checkers.Logic;

namespace C20_Ex05_Oz_203596275
{
    public class WindowsFormUI
    {
        private GameForm m_GameForm;
        private CheckersLogic m_CheckersLogic;
        private readonly GameSettings r_GameSettings;
        private DataGameOver? m_DataGameOver;
        public WindowsFormUI()
        {
            r_GameSettings = new GameSettings();
            m_CheckersLogic = null;
            m_GameForm = null;
            m_DataGameOver = null;
        }

        public void LaunchGame()
        {
            DialogResult dialogResult = r_GameSettings.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                startGame();
            }
        }

        private void initializeGame(bool i_NewGame = true)
        {
            m_DataGameOver = null;
            initializeGameLogic(i_NewGame);
            initializeGameForm();
        }

        private void initializeGameLogic(bool i_NewGame = true)
        {
            if(i_NewGame)
            {
                string[] playerNames = { r_GameSettings.Player1, r_GameSettings.Player2 };
                GameMode.eGameMode gameMode = getGameMode();

                m_CheckersLogic = new CheckersLogic();
                m_CheckersLogic.KingSet += gameLogic_KingSet;
                m_CheckersLogic.PlayerMoveSet += checkersLogic_PlayerMoveSet;
                m_CheckersLogic.TurnChanged += gameLogic_TurnChanged;
                m_CheckersLogic.GameOver += checkersLogic_GameOver;
                m_CheckersLogic.InitNewGame(gameMode, r_GameSettings.BoardSize, playerNames);
            }
            else
            {
                m_CheckersLogic.InitNewGame();
            }
        }

        private void checkersLogic_PlayerMoveSet(object i_Sender, PlayerMoveEventArgs i_PlayerMoveEventArgsEventArgs)
        {
            bool computerPlayer = m_CheckersLogic.PlayerTurn.Type == Player.eType.Computer;

            m_GameForm.SetCheckMenAnimation(i_PlayerMoveEventArgsEventArgs.PlayerMove, computerPlayer);
        }

        private void checkersLogic_GameOver(object i_Sender, GameStatusEventArgs i_GameStatusEventArgs)
        {
            if(i_GameStatusEventArgs.DataGameOver != null)
            {
                m_DataGameOver = i_GameStatusEventArgs.DataGameOver.Value;
            }

            m_GameForm.GameOver();
        }

        private void showMessageBoxGameOver(DataGameOver i_DataGameOver)
        {
            StringBuilder messageBoxText = new StringBuilder();

            if(i_DataGameOver.Draw)
            {
                messageBoxText.AppendLine("Tie!");
            }
            else
            {
                messageBoxText.AppendFormat("{0} Won!", i_DataGameOver.WinnerName).AppendLine();
            }

            messageBoxText.Append("Another Round?");
            DialogResult dialogResult = MessageBox.Show(
                messageBoxText.ToString(),
                "Damka",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            playAgain(dialogResult);
        }

        private void initializeGameForm()
        {
            m_GameForm = new GameForm(m_CheckersLogic.Board);
            m_GameForm.ComputerTurn += gameForm_ComputerTurn;
            m_GameForm.UserMoveSelected += gameForm_UserMoveSelected;
            m_GameForm.AnimationDone += gameForm_AnimationDone;
            setPlayersLabel();
            setPlayerTurnSlotButtonsEnable(
                m_CheckersLogic.PlayerTurn.RegularCheckersMen,
                m_CheckersLogic.PlayerTurn.KingCheckersMen);
        }

        private void gameForm_AnimationDone(object i_Sender, EventArgs i_EventArgs)
        {
            m_CheckersLogic.TurnEnd();
        }

        private void setPlayerQuitDataGameOver()
        {
            int score = m_CheckersLogic.PlayerEnemy.Score - m_CheckersLogic.PlayerTurn.Score;
            m_CheckersLogic.PlayerEnemy.Score += score;
            m_DataGameOver = new DataGameOver(
                m_CheckersLogic.PlayerEnemy.Name,
                m_CheckersLogic.PlayerTurn.Name,
                m_CheckersLogic.PlayerEnemy.Score,
                false,
                true);
        }

        private void gameForm_ComputerTurn()
        {
            computerPlayerPlay();
        }

        private void gameForm_UserMoveSelected(object i_Sender, UserMoveEventArgs i_UserMoveEventArgs)
        {
            humanPlayerPlay(i_UserMoveEventArgs.FromSlotKey, i_UserMoveEventArgs.ToSlotKey);
        }

        private void computerPlayerPlay()
        {
            m_CheckersLogic.ComputerPlay();
        }

        private void gameLogic_TurnChanged(TurnEventsArgs i_TurnEventArgs)
        {
            m_GameForm.ChangeTurn(
                i_TurnEventArgs.RegularCheckersMen,
                i_TurnEventArgs.KingCheckersMen,
                i_TurnEventArgs.PlayerTurnComputer);
        }

        private void humanPlayerPlay(string i_FromSlotKey, string i_ToSlotKey)
        {
            try
            {
                m_CheckersLogic.ProcessUserMove(i_FromSlotKey, i_ToSlotKey);
            }
            catch(Exception i_Exception)
            {
                MessageBox.Show(i_Exception.ToString());
            }
        }

        private void gameLogic_KingSet(object i_Sender, SlotContentEventArgs i_SlotContentEventArgs)
        {
            m_GameForm.SetSlotButtonContent(i_SlotContentEventArgs.Key, i_SlotContentEventArgs.Content);
        }

        private void playAgain(DialogResult i_DialogResult)
        {
            if(i_DialogResult == DialogResult.Yes)
            {
                startGame(false);
            }
        }

        private void startGame(bool i_NewGame = true)
        {
            initializeGame(i_NewGame);
            displayGame();
        }

        private void setPlayersLabel()
        {
            if(m_CheckersLogic.PlayerTurn.PlayerNumber == 1)
            {
                m_GameForm.SetPlayers(
                    m_CheckersLogic.PlayerTurn.Name,
                    m_CheckersLogic.PlayerTurn.Score,
                    m_CheckersLogic.PlayerEnemy.Name,
                    m_CheckersLogic.PlayerEnemy.Score);
            }
            else
            {
                m_GameForm.SetPlayers(
                    m_CheckersLogic.PlayerEnemy.Name,
                    m_CheckersLogic.PlayerEnemy.Score,
                    m_CheckersLogic.PlayerTurn.Name,
                    m_CheckersLogic.PlayerTurn.Score);
            }
        }

        private void setPlayerTurnSlotButtonsEnable(
            CheckersMen i_PlayerTurnRegularCheckersMen,
            CheckersMen i_PlayerTurnKingCheckersMen)
        {
            bool playerTurnIsComputer = m_CheckersLogic.PlayerTurn.Type == Player.eType.Computer;

            m_GameForm.SetSlotButtonsEnable(
                playerTurnIsComputer,
                i_PlayerTurnRegularCheckersMen,
                i_PlayerTurnKingCheckersMen);
        }

        private void displayGame()
        {
            m_GameForm.ShowDialog();
            if(m_DataGameOver == null)
            {
                setPlayerQuitDataGameOver();
            }

            showMessageBoxGameOver(m_DataGameOver.Value);
        }

        private GameMode.eGameMode getGameMode()
        {
            return (r_GameSettings.Player2IsHuman
                        ? GameMode.eGameMode.HumanVsHuman
                        : GameMode.eGameMode.HumanVsComputer);
        }
    }
}