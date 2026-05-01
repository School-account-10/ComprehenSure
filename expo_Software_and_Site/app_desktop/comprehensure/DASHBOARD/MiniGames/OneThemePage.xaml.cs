namespace comprehensure.DASHBOARD.MiniGames;

public partial class OneThemePage : ContentPage
{
    // ═══════════════════════════════════════════════════════════════
    //  DATA — all themes from Modules 1–8
    // ═══════════════════════════════════════════════════════════════

    private class ThemeQuestion
    {
        public string ModuleName   { get; set; } = "";   // e.g. "Module 1 · The Forgotten Library"
        public string Answer       { get; set; } = "";   // e.g. "CURIOSITY"
        public string ShuffledWord { get; set; } = "";   // e.g. "SIORUCITY"
        public string Hint         { get; set; } = "";   // short description
        // Image sources — replace with real asset names in your project
        public string Img1         { get; set; } = "";
        public string Img2         { get; set; } = "";
        public string Img3         { get; set; } = "";
        public string Img4         { get; set; } = "";
        // Emoji fallbacks shown when images are not found
        public string Emoji1       { get; set; } = "🖼";
        public string Emoji2       { get; set; } = "🖼";
        public string Emoji3       { get; set; } = "🖼";
        public string Emoji4       { get; set; } = "🖼";
    }

    private readonly List<ThemeQuestion> _allQuestions = new()
    {
        // ── MODULE 1 · THE FORGOTTEN LIBRARY ──────────────────────
        new ThemeQuestion
        {
            ModuleName   = "Module 1 · The Forgotten Library",
            Answer       = "CURIOSITY",
            ShuffledWord = "SIORUCITY",
            Hint         = "The invisible spark that leads a person to look behind a hidden shelf.",
            Img1 = "m1_curiosity_1.jpg", Img2 = "m1_curiosity_2.jpg",
            Img3 = "m1_curiosity_3.jpg", Img4 = "m1_curiosity_4.jpg",
            Emoji1 = "🔍", Emoji2 = "📦", Emoji3 = "👁", Emoji4 = "❓"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 1 · The Forgotten Library",
            Answer       = "KNOWLEDGE",
            ShuffledWord = "WLEDGEKNO",
            Hint         = "Something precious and powerful that can be learned, shared, or hidden in quiet places.",
            Img1 = "m1_knowledge_1.jpg", Img2 = "m1_knowledge_2.jpg",
            Img3 = "m1_knowledge_3.jpg", Img4 = "m1_knowledge_4.jpg",
            Emoji1 = "💡", Emoji2 = "📊", Emoji3 = "🤝", Emoji4 = "📚"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 1 · The Forgotten Library",
            Answer       = "HISTORY",
            ShuffledWord = "YRTOSIH",
            Hint         = "A collection of stories and choices from people who lived long before us.",
            Img1 = "m1_history_1.jpg", Img2 = "m1_history_2.jpg",
            Img3 = "m1_history_3.jpg", Img4 = "m1_history_4.jpg",
            Emoji1 = "🗺", Emoji2 = "🕰", Emoji3 = "🐴", Emoji4 = "🏛"
        },

        // ── MODULE 2 · THE CLOCKMAKER'S SECRET ────────────────────
        new ThemeQuestion
        {
            ModuleName   = "Module 2 · The Clockmaker's Secret",
            Answer       = "PATIENCE",
            ShuffledWord = "ECNEITAP",
            Hint         = "The quiet strength of slowing down to let a winding path reach its end.",
            Img1 = "m2_patience_1.jpg", Img2 = "m2_patience_2.jpg",
            Img3 = "m2_patience_3.jpg", Img4 = "m2_patience_4.jpg",
            Emoji1 = "🌧", Emoji2 = "⏳", Emoji3 = "🕰", Emoji4 = "🚶"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 2 · The Clockmaker's Secret",
            Answer       = "MESSAGE",
            ShuffledWord = "EGASSEM",
            Hint         = "A secret communication hidden within the shapes and patterns of a moving clock hand.",
            Img1 = "m2_message_1.jpg", Img2 = "m2_message_2.jpg",
            Img3 = "m2_message_3.jpg", Img4 = "m2_message_4.jpg",
            Emoji1 = "📱", Emoji2 = "🍾", Emoji3 = "👁‍🗨", Emoji4 = "🎤"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 2 · The Clockmaker's Secret",
            Answer       = "WISDOM",
            ShuffledWord = "SDWMOI",
            Hint         = "A deep understanding of how to use your time and mind for things that truly matter.",
            Img1 = "m2_wisdom_1.jpg", Img2 = "m2_wisdom_2.jpg",
            Img3 = "m2_wisdom_3.jpg", Img4 = "m2_wisdom_4.jpg",
            Emoji1 = "🌱", Emoji2 = "🔎", Emoji3 = "📖", Emoji4 = "⚙"
        },

        // ── MODULE 4 · THE GARDEN OF HIDDEN PATTERNS ──────────────
        new ThemeQuestion
        {
            ModuleName   = "Module 4 · The Garden of Hidden Patterns",
            Answer       = "INVESTIGATION",
            ShuffledWord = "GINIOTSAVETIN",
            Hint         = "A long walk through a hallway of 'whys' to find quiet details others miss.",
            Img1 = "m4_investigation_1.jpg", Img2 = "m4_investigation_2.jpg",
            Img3 = "m4_investigation_3.jpg", Img4 = "m4_investigation_4.jpg",
            Emoji1 = "🔬", Emoji2 = "📝", Emoji3 = "🪟", Emoji4 = "🔭"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 4 · The Garden of Hidden Patterns",
            Answer       = "REVELATION",
            ShuffledWord = "AOITNRVAELE",
            Hint         = "The rewarding moment when the veil is finally pulled back and hidden truth reveals itself.",
            Img1 = "m4_revelation_1.jpg", Img2 = "m4_revelation_2.jpg",
            Img3 = "m4_revelation_3.jpg", Img4 = "m4_revelation_4.jpg",
            Emoji1 = "🌿", Emoji2 = "🕵️", Emoji3 = "📌", Emoji4 = "📈"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 4 · The Garden of Hidden Patterns",
            Answer       = "HARMONY",
            ShuffledWord = "YNOMRAH",
            Hint         = "The delicate tension of a tightrope where opposite pulls create the surface to stand on.",
            Img1 = "m4_harmony_1.jpg", Img2 = "m4_harmony_2.jpg",
            Img3 = "m4_harmony_3.jpg", Img4 = "m4_harmony_4.jpg",
            Emoji1 = "🎨", Emoji2 = "🎸", Emoji3 = "🌉", Emoji4 = "🌸"
        },

        // ── MODULE 5 · THE MAP OF QUIET DECISIONS ─────────────────
        new ThemeQuestion
        {
            ModuleName   = "Module 5 · The Map of Quiet Decisions",
            Answer       = "ANTICIPATION",
            ShuffledWord = "NNTPIAIOCITA",
            Hint         = "The shadow of a mountain cast over a traveler long before they begin the climb.",
            Img1 = "m5_anticipation_1.jpg", Img2 = "m5_anticipation_2.jpg",
            Img3 = "m5_anticipation_3.jpg", Img4 = "m5_anticipation_4.jpg",
            Emoji1 = "✈", Emoji2 = "🪟", Emoji3 = "🛤", Emoji4 = "🏃"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 5 · The Map of Quiet Decisions",
            Answer       = "INTENTION",
            ShuffledWord = "ENTTOININ",
            Hint         = "The silent spark inside a stone that decides exactly where the crack will form.",
            Img1 = "m5_intention_1.jpg", Img2 = "m5_intention_2.jpg",
            Img3 = "m5_intention_3.jpg", Img4 = "m5_intention_4.jpg",
            Emoji1 = "🎯", Emoji2 = "✏", Emoji3 = "🌱", Emoji4 = "♟"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 5 · The Map of Quiet Decisions",
            Answer       = "CONTINUITY",
            ShuffledWord = "NTICOUNYIT",
            Hint         = "The invisible river that flows through a thousand different forests but never loses its name.",
            Img1 = "m5_continuity_1.jpg", Img2 = "m5_continuity_2.jpg",
            Img3 = "m5_continuity_3.jpg", Img4 = "m5_continuity_4.jpg",
            Emoji1 = "🏔", Emoji2 = "🁣", Emoji3 = "🪢", Emoji4 = "🌕"
        },

        // ── MODULE 6 · THE WEIGHT OF PAPER WINGS ──────────────────
        new ThemeQuestion
        {
            ModuleName   = "Module 6 · The Weight of Paper Wings",
            Answer       = "VULNERABILITY",
            ShuffledWord = "LIBERAVUNITYL",
            Hint         = "The thinness of a paper shield that only becomes unbreakable once you admit it can be torn.",
            Img1 = "m6_vulnerability_1.jpg", Img2 = "m6_vulnerability_2.jpg",
            Img3 = "m6_vulnerability_3.jpg", Img4 = "m6_vulnerability_4.jpg",
            Emoji1 = "🕊", Emoji2 = "🙈", Emoji3 = "😢", Emoji4 = "💔"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 6 · The Weight of Paper Wings",
            Answer       = "DISCIPLINE",
            ShuffledWord = "PDINELIISC",
            Hint         = "The invisible tether that keeps a wild kite steady in a storm, pulled tight by a focused mind.",
            Img1 = "m6_discipline_1.jpg", Img2 = "m6_discipline_2.jpg",
            Img3 = "m6_discipline_3.jpg", Img4 = "m6_discipline_4.jpg",
            Emoji1 = "🧘", Emoji2 = "⏰", Emoji3 = "🎻", Emoji4 = "🥋"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 6 · The Weight of Paper Wings",
            Answer       = "AWARENESS",
            ShuffledWord = "EESNRAWAS",
            Hint         = "The quiet observer who watches the shadow grow longer but does not run from the dark.",
            Img1 = "m6_awareness_1.jpg", Img2 = "m6_awareness_2.jpg",
            Img3 = "m6_awareness_3.jpg", Img4 = "m6_awareness_4.jpg",
            Emoji1 = "🌅", Emoji2 = "🍂", Emoji3 = "🏮", Emoji4 = "🌳"
        },

        // ── MODULE 7 · THE CITY OF SILENT BARGAINS ────────────────
        new ThemeQuestion
        {
            ModuleName   = "Module 7 · The City of Silent Bargains",
            Answer       = "PRESERVATION",
            ShuffledWord = "ESEVAPRTION",
            Hint         = "A glass case for time — stopping the clock so what is fragile today stays unbroken tomorrow.",
            Img1 = "m7_preservation_1.jpg", Img2 = "m7_preservation_2.jpg",
            Img3 = "m7_preservation_3.jpg", Img4 = "m7_preservation_4.jpg",
            Emoji1 = "🧶", Emoji2 = "🖼", Emoji3 = "🌿", Emoji4 = "🍯"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 7 · The City of Silent Bargains",
            Answer       = "RESONANCE",
            ShuffledWord = "SAEONNCER",
            Hint         = "A ghost in the wires — one strike on a string causes the whole room to hum with hidden energy.",
            Img1 = "m7_resonance_1.jpg", Img2 = "m7_resonance_2.jpg",
            Img3 = "m7_resonance_3.jpg", Img4 = "m7_resonance_4.jpg",
            Emoji1 = "〰", Emoji2 = "💧", Emoji3 = "✨", Emoji4 = "👥"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 7 · The City of Silent Bargains",
            Answer       = "RECIPROCATION",
            ShuffledWord = "ONCITACORPERI",
            Hint         = "The mirror that reaches out to take your shadow in return.",
            Img1 = "m7_reciprocation_1.jpg", Img2 = "m7_reciprocation_2.jpg",
            Img3 = "m7_reciprocation_3.jpg", Img4 = "m7_reciprocation_4.jpg",
            Emoji1 = "🤝", Emoji2 = "☂", Emoji3 = "💃", Emoji4 = "🎁"
        },

        // ── MODULE 8 · THE WHISPERS OF THE IRON FOREST ────────────
        new ThemeQuestion
        {
            ModuleName   = "Module 8 · The Whispers of the Iron Forest",
            Answer       = "INTROSPECTION",
            ShuffledWord = "NOISTCEPORTNI",
            Hint         = "A silent, internal search for a truth the mind has spent years trying to hide from itself.",
            Img1 = "m8_introspection_1.jpg", Img2 = "m8_introspection_2.jpg",
            Img3 = "m8_introspection_3.jpg", Img4 = "m8_introspection_4.jpg",
            Emoji1 = "🪞", Emoji2 = "🌌", Emoji3 = "🚪", Emoji4 = "📦"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 8 · The Whispers of the Iron Forest",
            Answer       = "SURRENDER",
            ShuffledWord = "RDRSRDUEE",
            Hint         = "The ultimate defeat of the ego that paradoxically results in the only way to win the journey.",
            Img1 = "m8_surrender_1.jpg", Img2 = "m8_surrender_2.jpg",
            Img3 = "m8_surrender_3.jpg", Img4 = "m8_surrender_4.jpg",
            Emoji1 = "🕊", Emoji2 = "🌬", Emoji3 = "🌧", Emoji4 = "🌊"
        },
        new ThemeQuestion
        {
            ModuleName   = "Module 8 · The Whispers of the Iron Forest",
            Answer       = "STAGNATION",
            ShuffledWord = "GNAITATSNO",
            Hint         = "A state of being frozen in time because one is unwilling to pay the cost of moving forward.",
            Img1 = "m8_stagnation_1.jpg", Img2 = "m8_stagnation_2.jpg",
            Img3 = "m8_stagnation_3.jpg", Img4 = "m8_stagnation_4.jpg",
            Emoji1 = "🧊", Emoji2 = "👤", Emoji3 = "🌵", Emoji4 = "🏚"
        },
    };

    // ═══════════════════════════════════════════════════════════════
    //  STATE
    // ═══════════════════════════════════════════════════════════════

    private List<ThemeQuestion> _questions = new();
    private int    _currentIndex  = 0;
    private int    _attemptsLeft  = 3;
    private int    _score         = 0;
    private bool   _roundFinished = false;

    // ═══════════════════════════════════════════════════════════════
    //  INIT
    // ═══════════════════════════════════════════════════════════════

    public OneThemePage()
    {
        InitializeComponent();
        StartNewGame();
    }

    private void StartNewGame()
    {
        // Shuffle all questions
        var rng = new Random();
        _questions = _allQuestions.OrderBy(_ => rng.Next()).ToList();
        _currentIndex = 0;
        _score        = 0;
        UpdateScoreLabel();
        LoadQuestion();
    }

    // ═══════════════════════════════════════════════════════════════
    //  LOAD QUESTION
    // ═══════════════════════════════════════════════════════════════

    private void LoadQuestion()
    {
        if (_currentIndex >= _questions.Count)
        {
            ShowGameOver();
            return;
        }

        _attemptsLeft  = 3;
        _roundFinished = false;

        var q = _questions[_currentIndex];

        // Round pills
        UpdateRoundPills();

        // Module label
        ModuleLabel.Text = q.ModuleName;

        // Images
        SetImage(Img1, ImgLabel1, q.Img1, q.Emoji1);
        SetImage(Img2, ImgLabel2, q.Img2, q.Emoji2);
        SetImage(Img3, ImgLabel3, q.Img3, q.Emoji3);
        SetImage(Img4, ImgLabel4, q.Img4, q.Emoji4);

        // Reset hearts
        Heart1.Text = "❤️";
        Heart2.Text = "❤️";
        Heart3.Text = "❤️";

        // Reset hint
        HintBorder.IsVisible   = false;
        HintContentLabel.Text  = "";
        HintDescLabel.Text     = "";

        // Reset feedback & entry
        FeedbackLabel.Text     = "";
        AnswerEntry.Text       = "";
        AnswerEntry.IsEnabled  = true;
        SubmitButton.IsVisible = true;
        NextButton.IsVisible   = false;
    }

    private static void SetImage(Image img, Label label, string source, string emoji)
    {
        if (!string.IsNullOrEmpty(source))
        {
            img.Source  = ImageSource.FromFile(source);
            img.Opacity = 1;
            label.IsVisible = false;
        }
        else
        {
            img.Opacity     = 0;
            label.IsVisible = true;
            label.Text      = emoji;
        }
    }

    // ═══════════════════════════════════════════════════════════════
    //  SUBMIT
    // ═══════════════════════════════════════════════════════════════

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (_roundFinished) return;

        var q      = _questions[_currentIndex];
        var answer = (AnswerEntry.Text ?? "").Trim().ToUpperInvariant();
        var correct = q.Answer.ToUpperInvariant();

        if (answer == correct)
        {
            _score        += 5;
            _roundFinished = true;
            UpdateScoreLabel();
            FeedbackLabel.TextColor = Color.FromArgb("#22C55E");
            FeedbackLabel.Text      = $"✅  Correct! +5 points";
            AnswerEntry.IsEnabled   = false;
            SubmitButton.IsVisible  = false;
            NextButton.IsVisible    = true;
            await Task.Delay(200);
            return;
        }

        // Wrong answer
        _attemptsLeft--;
        LoseHeart();

        if (_attemptsLeft == 2)
        {
            // After 1st wrong — show blank hint (letter count)
            ShowBlankHint(q);
            FeedbackLabel.TextColor = Color.FromArgb("#F59E0B");
            FeedbackLabel.Text      = "❌  Incorrect. Here's a hint — count the letters!";
        }
        else if (_attemptsLeft == 1)
        {
            // After 2nd wrong — show shuffled word
            ShowShuffledHint(q);
            FeedbackLabel.TextColor = Color.FromArgb("#F59E0B");
            FeedbackLabel.Text      = "❌  Try again! The letters are shuffled above.";
        }
        else
        {
            // No attempts left
            _roundFinished = true;
            ShowAnswer(q);
            FeedbackLabel.TextColor = Color.FromArgb("#EF4444");
            FeedbackLabel.Text      = $"💔  Out of tries! The answer was: {q.Answer}";
            AnswerEntry.IsEnabled   = false;
            SubmitButton.IsVisible  = false;
            NextButton.IsVisible    = true;
        }

        AnswerEntry.Text = "";
    }

    // ─── Hint helpers ───────────────────────────────────────────

    /// After 1st wrong: show blank underscores + description
    private void ShowBlankHint(ThemeQuestion q)
    {
        HintBorder.IsVisible  = true;
        HintTitleLabel.Text   = "💡  HINT — How many letters?";
        HintContentLabel.Text = new string('_', q.Answer.Length);
        HintDescLabel.Text    = q.Hint;
    }

    /// After 2nd wrong: replace underscores with shuffled word
    private void ShowShuffledHint(ThemeQuestion q)
    {
        HintBorder.IsVisible  = true;
        HintTitleLabel.Text   = "🔀  HINT — Unscramble!";
        HintContentLabel.Text = q.ShuffledWord;
        HintDescLabel.Text    = q.Hint;
    }

    /// After 3 wrong: reveal full answer in hint area
    private void ShowAnswer(ThemeQuestion q)
    {
        HintBorder.IsVisible  = true;
        HintTitleLabel.Text   = "✔  ANSWER";
        HintContentLabel.Text = q.Answer;
        HintDescLabel.Text    = q.Hint;
    }

    // ─── Heart tracker ───────────────────────────────────────────

    private void LoseHeart()
    {
        var lost = 3 - _attemptsLeft;
        if (lost >= 1) Heart1.Text = "🖤";
        if (lost >= 2) Heart2.Text = "🖤";
        if (lost >= 3) Heart3.Text = "🖤";
    }

    // ─── Round pills ─────────────────────────────────────────────

    private void UpdateRoundPills()
    {
        int display = (_currentIndex % 3) + 1;

        void SetPill(Border pill, Label lbl, int num)
        {
            bool active = num == display;
            pill.BackgroundColor = active
                ? Color.FromArgb("#1565C0")
                : Color.FromArgb("#1A3A6B");
            lbl.TextColor = active
                ? Colors.White
                : Color.FromArgb("#93C5FD");
        }

        // The round pills hold a single child Label — access via content
        var p1l = (Label)((Border)Round1Pill).Content;
        var p2l = (Label)((Border)Round2Pill).Content;
        var p3l = (Label)((Border)Round3Pill).Content;

        SetPill(Round1Pill, p1l, 1);
        SetPill(Round2Pill, p2l, 2);
        SetPill(Round3Pill, p3l, 3);
    }

    private void UpdateScoreLabel()
    {
        ScoreLabel.Text = $"{_score} pts";
    }

    // ═══════════════════════════════════════════════════════════════
    //  NAVIGATION
    // ═══════════════════════════════════════════════════════════════

    private void OnNextClicked(object sender, EventArgs e)
    {
        _currentIndex++;
        LoadQuestion();
    }

    private void OnSkipClicked(object sender, EventArgs e)
    {
        // Skip counts as a loss for this round — no points
        _currentIndex++;
        LoadQuestion();
    }

    private async void ShowGameOver()
    {
        bool playAgain = await DisplayAlert(
            "Game Over! 🎉",
            $"You completed all rounds!\nFinal Score: {_score} pts",
            "Play Again",
            "Exit");

        if (playAgain)
            StartNewGame();
        else
            await Shell.Current.GoToAsync("..");
    }

    // ═══════════════════════════════════════════════════════════════
    //  EXIT
    // ═══════════════════════════════════════════════════════════════

    private async void OnExitClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
