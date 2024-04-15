using Masters_Summer_Project_CsharpPart2_Quiz.Models;

namespace Masters_Summer_Project_CsharpPart2_Quiz.ViewModels.Presentations;

public class QuizProperty : PropertyChange
{
	public readonly Quiz _quiz = new Quiz();
	public Quiz Quiz { get => _quiz; set { if (Quiz != value) Quiz = value; } }

	public string Title
	{
		get => _quiz.Title;
		set { _quiz.Title = value; OnPropertyChanged(nameof(Title)); }
	}

	public List<Question> Questions
	{
		get => _quiz.Questions;
		set { _quiz.Questions = value; OnPropertyChanged(nameof(Questions)); }
	}

	public User User
	{
		get => User;
		set { User = value; OnPropertyChanged(nameof(User)); }
	}

	public QuizProperty()
	{
	}

}
