using TennisScoreboardApp.Shared.Enums;

namespace TennisScoreboardApp.Client.Services.Interfaces;

public interface ITennisScoreService
{
	TennisScore GetPlayerOnePointScore();
	TennisScore GetPlayerTwoPointScore();
	void IncrementPlayerOnePointScore();
	void IncrementPlayerTwoPointScore();
	bool ShowPlayerOnePointScore();
	bool ShowPlayerTwoPointScore();

	int GetPlayerOneGameScore();
	int GetPlayerTwoGameScore();
	void IncrementPlayerOneGameScore();
	void IncrementPlayerTwoGameScore();

	int GetPlayerOneSetScore();
	int GetPlayerTwoSetScore();
	void IncrementPlayerOneSetScore();
	void IncrementPlayerTwoSetScore();
	bool IsPlayerOneVictorious();
	bool IsPlayerTwoVictorious();
	void Reset();
}