﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Ex05.Checkers.GameLogic;

namespace Ex05.Checkers.Logic
{
    public class CheckersLogic
    {
        private CheckersBoard m_Board;
        private GameMode.eGameMode? m_GameMode;
        private Player m_PlayerTurn;
        private Player m_PlayerEnemy;
        private bool m_GameOver;
        private DataGameOver? m_DataGameOver;

        public event SlotContentEventHandler KingSet;

        public event PlayerMoveEventHandler PlayerMoveSet;

        public event TurnEventHandler TurnChanged;

        public event GameStatusEventHandler GameOver;

        public CheckersLogic()
        {
            m_GameOver = false;
            m_DataGameOver = null;
            m_Board = null;
            m_PlayerTurn = null;
            m_PlayerEnemy = null;
            m_GameMode = null;
            TurnChanged = null;
        }

        public CheckersBoard Board
        {
            get
            {
                return m_Board;
            }
        }

        public Player PlayerTurn
        {
            get
            {
                return m_PlayerTurn;
            }
        }

        public Player PlayerEnemy
        {
            get
            {
                return m_PlayerEnemy;
            }
        }

        public DataGameOver? DataGameOver
        {
            get
            {
                return m_DataGameOver ?? null;
            }
        }

        public void InitNewGame(
            GameMode.eGameMode? i_GameMode = null,
            int i_BoardSize = 0,
            string[] i_PlayersNames = null)
        {
            m_GameOver = false;
            m_DataGameOver = null;
            if(i_GameMode != null)
            {
                m_GameMode = i_GameMode.Value;
            }

            setBoard(i_BoardSize);
            setPlayers(i_PlayersNames);
        }

        private void setNewPlayers(string[] i_PlayersNames)
        {
            int amountOfCheckersMenFoEachPlayer = m_Board.GetAmountOfCheckersMen(CheckersMen.eSign.O);

            m_PlayerTurn = new Player(
                i_PlayersNames[0],
                1,
                Player.eType.Human,
                CheckersMen.eSign.X,
                CheckersMen.eSign.K,
                m_Board.MaxRowKey,
                amountOfCheckersMenFoEachPlayer);
            if(m_GameMode == GameMode.eGameMode.HumanVsHuman)
            {
                m_PlayerEnemy = new Player(
                    i_PlayersNames[1],
                    2,
                    Player.eType.Human,
                    CheckersMen.eSign.O,
                    CheckersMen.eSign.U,
                    m_Board.MinRowKey,
                    amountOfCheckersMenFoEachPlayer);
            }
            else
            {
                m_PlayerEnemy = new Player(
                    "Computer",
                    2,
                    Player.eType.Computer,
                    CheckersMen.eSign.O,
                    CheckersMen.eSign.U,
                    m_Board.MinRowKey,
                    amountOfCheckersMenFoEachPlayer);
            }
        }

        private void setPlayers(string[] i_PlayersNames = null)
        {
            if(i_PlayersNames == null)
            {
                int amountOfCheckersMenFoEachPlayer = m_Board.GetAmountOfCheckersMen(CheckersMen.eSign.O);
                m_PlayerTurn.AmountOfMenOnBoard = amountOfCheckersMenFoEachPlayer;
                m_PlayerTurn.ClearPossibleMoves();
                m_PlayerTurn.ClearLastMovesPlayed();
                m_PlayerTurn.CanEatAgain = false;
                m_PlayerEnemy.AmountOfMenOnBoard = amountOfCheckersMenFoEachPlayer;
                m_PlayerEnemy.ClearPossibleMoves();
                m_PlayerEnemy.ClearLastMovesPlayed();
                m_PlayerEnemy.CanEatAgain = false;
            }
            else
            {
                setNewPlayers(i_PlayersNames);
            }

            SetPossibleMovesToPlayer(m_PlayerTurn);
        }

        private void setBoard(int i_BoardSize = 0)
        {
            if(m_Board == null)
            {
                m_Board = new CheckersBoard(i_BoardSize);

            }
            else
            {
                m_Board = new CheckersBoard(m_Board.Size);
            }
        }

        private List<PlayerMove> getPossiblePlayerMovesOnBoard(Player i_Player)
        {
            List<PlayerMove> possiblePlayerMoves = new List<PlayerMove>();

            foreach(KeyValuePair<string, BoardSlot> slot in m_Board.Dictionary)
            {
                if(isSlotKeyBelongsToPlayer(slot.Key, i_Player))
                {

                    List<PlayerMove> possibleSlotMoves = getPossibleSlotMoves(slot.Value, i_Player.Direction);
                    possiblePlayerMoves.AddRange(possibleSlotMoves);
                }
            }

            return possiblePlayerMoves;
        }

        public bool SetPossibleMovesToPlayer(Player io_Player, List<PlayerMove> i_PossiblePlayerMoves = null)
        {
            bool setPossibleMovesToPlayer = false;

            io_Player.ClearPossibleMoves();
            if(io_Player.AmountOfMenOnBoard > 0)
            {
                List<PlayerMove> possiblePlayerMoves = null;

                if(i_PossiblePlayerMoves == null)
                {
                    possiblePlayerMoves = getPossiblePlayerMovesOnBoard(io_Player);
                    filterPlayerMovesByTypeIfExist(PlayerMove.eMoveType.Eat, ref possiblePlayerMoves);
                }
                else
                {
                    possiblePlayerMoves = i_PossiblePlayerMoves;
                }

                setPossibleMovesToPlayer = possiblePlayerMoves.Count > 0;
                if(setPossibleMovesToPlayer)
                {
                    io_Player.AddPossibleMoves(possiblePlayerMoves);
                }
            }

            return setPossibleMovesToPlayer;
        }

        private bool filterPlayerMovesByTypeIfExist(
            PlayerMove.eMoveType i_FilterType,
            ref List<PlayerMove> io_PlayerMoves)
        {
            List<PlayerMove> filteredList = new List<PlayerMove>(0);

            foreach(PlayerMove playerMove in io_PlayerMoves)
            {
                if(playerMove.Type == i_FilterType)
                {
                    filteredList.Add(playerMove);
                }
            }

            bool filterSucceeded = filteredList.Count > 0;
            if(filterSucceeded)
            {
                io_PlayerMoves = filteredList;
            }

            return filterSucceeded;
        }

        private bool isSlotKeyBelongsToPlayer(string i_SlotKey, Player i_Player)
        {
            CheckersMen? slotContent = m_Board[i_SlotKey].Content;
            bool slotBelongsToPlayerTurn = false;

            if(slotContent != null)
            {
                if(slotContent.Value.Type == CheckersMen.eType.Regular)
                {
                    slotBelongsToPlayerTurn = slotContent.Value.Sign == i_Player.RegularCheckersMen.Sign;
                }
                else
                {
                    slotBelongsToPlayerTurn = slotContent.Value.Sign == i_Player.KingCheckersMen.Sign;
                }
            }

            return slotBelongsToPlayerTurn;
        }

        private List<PlayerMove> getPossibleSlotMoves(BoardSlot i_Slot, Direction i_Direction)
        {
            List<PlayerMove> possibleSlotMoves = new List<PlayerMove>();
            CheckersMen.eType slotMenType = i_Slot.Content.Value.Type;

            setPlayerMoveByDirection(i_Slot.Key, i_Direction.Forward, i_Direction.Left, ref possibleSlotMoves);
            setPlayerMoveByDirection(i_Slot.Key, i_Direction.Forward, i_Direction.Right, ref possibleSlotMoves);
            if(slotMenType == CheckersMen.eType.King)
            {
                setPlayerMoveByDirection(i_Slot.Key, i_Direction.Backward, i_Direction.Left, ref possibleSlotMoves);
                setPlayerMoveByDirection(i_Slot.Key, i_Direction.Backward, i_Direction.Right, ref possibleSlotMoves);
            }

            return possibleSlotMoves;
        }

        private Player getSlotOwner(string i_SlotKey)
        {
            Player requiredPlayer = null;
            CheckersMen? slotContent = m_Board[i_SlotKey].Content;

            if(slotContent != null)
            {
                if(slotContent.Value.Sign == m_PlayerTurn.RegularCheckersMen.Sign
                   || slotContent.Value.Sign == m_PlayerTurn.KingCheckersMen.Sign)
                {
                    requiredPlayer = m_PlayerTurn;
                }
                else
                {
                    requiredPlayer = m_PlayerEnemy;
                }
            }

            return requiredPlayer;
        }

        private void setPlayerMoveByDirection(
            string i_FromSlotKey,
            int i_RowDirection,
            int i_ColumnDirection,
            ref List<PlayerMove> o_PossibleSlotMoves)
        {
            string toSlotKey = m_Board.GetSlotKeyByDirection(i_FromSlotKey, i_RowDirection, i_ColumnDirection);

            if(toSlotKey != null)
            {

                PlayerMove? playerMove = null;
                Player fromSlotOwner = getSlotOwner(i_FromSlotKey);

                if(m_Board[toSlotKey].isEmpty())
                {
                    playerMove = new PlayerMove(i_FromSlotKey, toSlotKey, null, PlayerMove.eMoveType.NoEat);
                }
                else if(!isSlotKeyBelongsToPlayer(toSlotKey, fromSlotOwner))
                {
                    string nextSlotKey = m_Board.GetSlotKeyByDirection(toSlotKey, i_RowDirection, i_ColumnDirection);
                    if(nextSlotKey != null && m_Board[nextSlotKey].isEmpty())
                    {
                        playerMove = new PlayerMove(i_FromSlotKey, nextSlotKey, toSlotKey, PlayerMove.eMoveType.Eat);
                    }
                }

                if(playerMove != null)
                {
                    o_PossibleSlotMoves.Add(playerMove.Value);
                }
            }
        }

        public bool ProcessUserMove(string i_FromSlotKey, string i_ToSlotKey)
        {
            bool processSucceeded = false;

            if(isUserMoveKeysLegal(i_FromSlotKey, i_ToSlotKey))
            {
                if(isUserMoveInPLayerTurnPossibleMoves(i_FromSlotKey, i_ToSlotKey, out int? possibleMovesIndex))
                {
                    setPlayerMove(possibleMovesIndex.Value);
                    processSucceeded = true;
                }
            }

            return processSucceeded;
        }

        private void updatePlayerTurnLastMoves(PlayerMove i_PlayerMove)
        {
            if(!PlayerTurn.CanEatAgain)
            {
                PlayerTurn.ClearLastMovesPlayed();
            }

            m_PlayerTurn.AddLastMovePlayed(i_PlayerMove);
        }

        private void setPlayerMove(int i_PlayerMoveIndex)
        {
            PlayerMove playerMove = m_PlayerTurn.PossibleMoves[i_PlayerMoveIndex];

            playerMoveEatHandler(playerMove);
            setPlayerMove(playerMove);
            updatePlayerTurnLastMoves(playerMove);
        }

        private void setPlayerMove(PlayerMove i_PlayerMove)
        {
            m_Board.SetPlayerMove(i_PlayerMove);
            onPlayerMoveSet(new PlayerMoveEventArgs(i_PlayerMove));
        }

        private void onPlayerMoveSet(PlayerMoveEventArgs i_EventArgs)
        {
            if(PlayerMoveSet != null)
            {
                PlayerMoveSet.Invoke(this, i_EventArgs);
            }
        }

        private void onKingSet(SlotContentEventArgs i_EventArgs)
        {
            if(KingSet != null)
            {
                KingSet.Invoke(this, i_EventArgs);

            }
        }

        private void gameOverChecker(bool i_PlayerEnemyHavePossibleMoves, bool i_PlayerTurnHavePossibleMoves)
        {
            if(!i_PlayerEnemyHavePossibleMoves)
            {
                int score = m_PlayerTurn.AmountOfMenOnBoard - m_PlayerEnemy.AmountOfMenOnBoard;
                bool draw = false;

                m_GameOver = true;
                if(!i_PlayerTurnHavePossibleMoves)
                {
                    draw = true;
                }
                else
                {
                    m_PlayerTurn.Score += score;
                }

                m_DataGameOver = new DataGameOver(m_PlayerTurn.Name, m_PlayerEnemy.Name, score, draw);
            }
        }

        private void onGameOver(GameStatusEventArgs i_GameStatusEventArgs)
        {
            if(GameOver != null)
            {
                GameOver.Invoke(this, i_GameStatusEventArgs);
            }
        }

        private void playerMoveEatHandler(PlayerMove i_PlayerMove)
        {
            if(i_PlayerMove.Type == PlayerMove.eMoveType.Eat)
            {
                int CheckerMenValue = m_Board[i_PlayerMove.SlotKeyToEat].Content.Value.Value;
                m_PlayerEnemy.AmountOfMenOnBoard -= CheckerMenValue;
            }
        }

        private void checkIfPlayerMoveToEnemyBaseLine(PlayerMove i_PlayerMove)
        {
            CheckersBoard.GetRowAndColumnFromKey(
                i_PlayerMove.ToSlotKey,
                out char toRowKeyPlayerMove,
                out char toColumnKeyPlayerMove);

            if(toRowKeyPlayerMove == m_PlayerEnemy.BaseLineRowKey)
            {
                CheckersMen slotContent = m_Board[i_PlayerMove.ToSlotKey].Content.Value;

                if(slotContent.Type == CheckersMen.eType.Regular)
                {
                    setKing(i_PlayerMove.ToSlotKey);

                }
            }
        }

        private void setKing(string i_SlotKey)
        {
            BoardSlot slot = m_Board[i_SlotKey];
            CheckersMen king = new CheckersMen(CheckersMen.eSign.K);

            if(slot.Content.Value.Sign == CheckersMen.eSign.O)
            {
                king = new CheckersMen(CheckersMen.eSign.U);
            }

            m_PlayerTurn.AmountOfMenOnBoard += king.Value - slot.Content.Value.Value;
            m_Board[i_SlotKey].Content = king;
            onKingSet(new SlotContentEventArgs(i_SlotKey, king));
        }

        private bool isPlayerTurnPossibleToEatAgain(out List<PlayerMove> o_PossibleSlotMoves)
        {
            o_PossibleSlotMoves = null;
            bool possibleToEatAgain = false;
            PlayerMove lastPlayerMove = m_PlayerTurn.LastMovesPlayed.Last();

            if(lastPlayerMove.Type == PlayerMove.eMoveType.Eat)
            {
                string menSlotIndex = lastPlayerMove.ToSlotKey;

                o_PossibleSlotMoves = getPossibleSlotMoves(m_Board[menSlotIndex], m_PlayerTurn.Direction);
                possibleToEatAgain = filterPlayerMovesByTypeIfExist(PlayerMove.eMoveType.Eat, ref o_PossibleSlotMoves);
            }

            return possibleToEatAgain;
        }

        private void decidePlayerTurn()
        {
            PlayerTurn.CanEatAgain = isPlayerTurnPossibleToEatAgain(out List<PlayerMove> possibleSlotMoves);
            if(PlayerTurn.CanEatAgain)
            {
                SetPossibleMovesToPlayer(m_PlayerTurn, possibleSlotMoves);
            }
            else
            {
                ChangeTurn();
            }

            bool playerTurnComputer = PlayerTurn.Type == Player.eType.Computer;
            onTurnChanged(
                new TurnEventsArgs(m_PlayerTurn.RegularCheckersMen, m_PlayerTurn.KingCheckersMen, playerTurnComputer));
        }

        private void onTurnChanged(TurnEventsArgs i_TurnEventArgs)
        {
            if(TurnChanged != null)
            {
                TurnChanged.Invoke(i_TurnEventArgs);
            }
        }

        public void ChangeTurn()
        {
            Player currenPlayer = m_PlayerTurn;

            m_PlayerTurn = m_PlayerEnemy;
            m_PlayerEnemy = currenPlayer;
        }

        public void TurnEnd()
        {
            checkIfPlayerMoveToEnemyBaseLine(m_PlayerTurn.LastMovesPlayed.Last());
            bool playerEnemyHavePossibleMoves = SetPossibleMovesToPlayer(m_PlayerEnemy);
            bool playerTurnHavePossibleMoves = SetPossibleMovesToPlayer(m_PlayerTurn);

            gameOverChecker(playerEnemyHavePossibleMoves, playerTurnHavePossibleMoves);
            if(!m_GameOver)
            {
                decidePlayerTurn();
            }
            else
            {
                onGameOver(new GameStatusEventArgs(m_DataGameOver.Value));
            }
        }

        private bool isUserMoveKeysLegal(string i_FromSlotKey, string i_ToSlotKey)
        {
            bool fromSlotKeyLegal = m_Board.IsKeyInRange(i_FromSlotKey);
            bool toSlotKeyLegal = m_Board.IsKeyInRange(i_ToSlotKey);

            if(!fromSlotKeyLegal && !toSlotKeyLegal)
            {
                throw new SlotKeysAreNotInRangeException(i_FromSlotKey, i_ToSlotKey);
            }

            if(!fromSlotKeyLegal)
            {
                throw new SlotKeyIsNotInRangeException(i_FromSlotKey);
            }

            if(!toSlotKeyLegal)
            {
                throw new SlotKeyIsNotInRangeException(i_ToSlotKey);
            }

            return true;
        }

        private bool isUserMoveInPLayerTurnPossibleMoves(
            string i_FromSlotKey,
            string i_ToSlotKey,
            out int? o_PossibleMovesIndex)
        {

            o_PossibleMovesIndex = 0;
            bool isExists = false;

            foreach(PlayerMove playerMove in m_PlayerTurn.PossibleMoves)
            {
                isExists = i_FromSlotKey == playerMove.FromSlotKey && i_ToSlotKey == playerMove.ToSlotKey;
                if(isExists)
                {
                    break;
                }

                o_PossibleMovesIndex++;
            }

            if(!isExists)
            {
                o_PossibleMovesIndex = null;

                throwErrorUserMoveDidNotFoundInPossibleMoves(i_FromSlotKey, i_ToSlotKey);

            }

            return isExists;
        }

        private void throwErrorUserMoveDidNotFoundInPossibleMoves(string i_FromSlotKey, string i_ToSlotKey)
        {
            bool playerMoveMustEat = isPlayMoveMustEat();

            if(playerMoveMustEat)
            {
                if(m_PlayerTurn.CanEatAgain)
                {
                    throw new PlayerMustToEatAgainException();

                }
                else
                {
                    throw new DidNotMoveToEatException();
                }
            }
            else
            {
                throw new NotPossibleMoveException(i_FromSlotKey, i_ToSlotKey);
            }
        }

        private bool isPlayMoveMustEat()
        {
            bool playMoveMustEat = false;

            if(PlayerTurn.PossibleMoves.Count > 0)
            {
                playMoveMustEat = m_PlayerTurn.PossibleMoves[0].Type == PlayerMove.eMoveType.Eat;
            }

            return playMoveMustEat;
        }

        public void ComputerPlay()
        {
            int playMoveIndex = PlayerTurn.GetIndexOfRandomPlayMove();
         
            setPlayerMove(playMoveIndex);
        }
    }
}

