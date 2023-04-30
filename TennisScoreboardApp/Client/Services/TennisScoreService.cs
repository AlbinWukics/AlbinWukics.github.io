using TennisScoreboardApp.Client.Services.Interfaces;
using TennisScoreboardApp.Shared.Enums;

namespace TennisScoreboardApp.Client.Services;

public class TennisScoreService : ITennisScoreService
{
	#region Fields

	private TennisScore _playerOne = TennisScore.Love;
	private TennisScore _playerTwo = TennisScore.Love;
	private int _playerOneGameScore;
	private int _playerTwoGameScore;
	private int _playerOneSetScore;
	private int _playerTwoSetScore;
	private bool _playerOneVictory;
	private bool _playerTwoVictory;

	#endregion

	#region GetMethods

	public TennisScore GetPlayerOnePointScore()
	{
		return _playerOne;
	}

	public TennisScore GetPlayerTwoPointScore()
	{
		return _playerTwo;
	}

	public int GetPlayerOneGameScore()
	{
		return _playerOneGameScore;
	}

	public int GetPlayerTwoGameScore()
	{
		return _playerTwoGameScore;
	}

	public int GetPlayerOneSetScore()
	{
		return _playerOneSetScore;
	}

	public int GetPlayerTwoSetScore()
	{
		return _playerTwoSetScore;
	}

	#endregion

	public void IncrementPlayerOnePointScore()
	{

		if (_playerOne == TennisScore.Forty && _playerTwo < TennisScore.Forty)
		{
			_playerOne = TennisScore.Love;
			_playerTwo = TennisScore.Love;
			// Game score for playerOne
			IncrementPlayerOneGameScore();
			return;
		}

		if (_playerOne == TennisScore.Advantage)
		{
			_playerOne = TennisScore.Love;
			_playerTwo = TennisScore.Love;
			// Game score for playerOne
			IncrementPlayerOneGameScore();
			return;
		}

		if (_playerOne == TennisScore.Deuce && _playerTwo == TennisScore.Advantage)
		{
			_playerTwo = TennisScore.Deuce;
			return;
		}

		if (_playerOne == TennisScore.Deuce && _playerTwo == TennisScore.Deuce)
		{
			_playerOne = TennisScore.Advantage;
			return;
		}

		_playerOne = _playerOne switch
		{
			TennisScore.Love => TennisScore.Fifteen,
			TennisScore.Fifteen => TennisScore.Thirty,
			TennisScore.Thirty => TennisScore.Forty,
			_ => _playerOne
		};

		if (_playerOne == TennisScore.Forty && _playerTwo == TennisScore.Forty)
		{
			_playerOne = TennisScore.Deuce;
			_playerTwo = TennisScore.Deuce;
		}
	}

	public void IncrementPlayerTwoPointScore()
	{
		if (_playerTwo == TennisScore.Forty && _playerOne < TennisScore.Forty)
		{
			_playerOne = TennisScore.Love;
			_playerTwo = TennisScore.Love;
			// Game score for playerTwo
			IncrementPlayerTwoGameScore();
			return;
		}

		if (_playerTwo == TennisScore.Advantage)
		{
			_playerOne = TennisScore.Love;
			_playerTwo = TennisScore.Love;
			// Game score for playerTwo
			IncrementPlayerTwoGameScore();
			return;
		}

		if (_playerTwo == TennisScore.Deuce && _playerOne == TennisScore.Advantage)
		{
			_playerOne = TennisScore.Deuce;
			return;
		}

		if (_playerTwo == TennisScore.Deuce && _playerOne == TennisScore.Deuce)
		{
			_playerTwo = TennisScore.Advantage;
			return;
		}

		_playerTwo = _playerTwo switch
		{
			TennisScore.Love => TennisScore.Fifteen,
			TennisScore.Fifteen => TennisScore.Thirty,
			TennisScore.Thirty => TennisScore.Forty,
			_ => _playerTwo
		};

		if (_playerTwo == TennisScore.Forty && _playerOne == TennisScore.Forty)
		{
			_playerOne = TennisScore.Deuce;
			_playerTwo = TennisScore.Deuce;
		}
	}

	public bool ShowPlayerOnePointScore()
	{
		return _playerTwo != TennisScore.Advantage;
	}

	public bool ShowPlayerTwoPointScore()
	{
		return _playerOne != TennisScore.Advantage;
	}


	public void IncrementPlayerOneGameScore()
	{
		_playerOneGameScore++;

		if (_playerOneGameScore > 6)
		{
			IncrementPlayerOneSetScore();
			_playerOneGameScore = 0;
			_playerTwoGameScore = 0;
		}
	}

	public void IncrementPlayerTwoGameScore()
	{
		_playerTwoGameScore++;

		if (_playerTwoGameScore > 6)
		{
			IncrementPlayerTwoSetScore();
			_playerOneGameScore = 0;
			_playerTwoGameScore = 0;
		}
	}


	public void IncrementPlayerOneSetScore()
	{
		_playerOneSetScore++;

		if (_playerOneSetScore > 1 && _playerTwoVictory is false)
		{
			_playerOneVictory = true;
		}
	}

	public void IncrementPlayerTwoSetScore()
	{
		_playerTwoSetScore++;

		if (_playerTwoSetScore > 1 && _playerOneVictory is false)
		{
			_playerTwoVictory = true;
		}
	}

	public bool IsPlayerOneVictorious()
	{
		return _playerOneVictory;
	}

	public bool IsPlayerTwoVictorious()
	{
		return _playerTwoVictory;
	}

	public void Reset()
	{
		_playerOne = TennisScore.Love;
		_playerTwo = TennisScore.Love;
		_playerOneGameScore = 0;
		_playerTwoGameScore = 0;

		_playerOneSetScore = 0;
		_playerTwoSetScore = 0;

		_playerOneVictory = false;
		_playerTwoVictory = false;
	}
}