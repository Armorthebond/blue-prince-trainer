"""Tests for the Blue Prince Trainer."""

import unittest
from unittest.mock import patch, MagicMock
from src.trainer import BluePrinceTrainer

class TestBluePrinceTrainer(unittest.TestCase):
    """Test suite for BluePrinceTrainer."""

    def setUp(self):
        self.trainer = BluePrinceTrainer(hotkey="ctrl+shift+t")

    def test_initial_state(self):
        """Test that trainer starts in disabled state."""
        self.assertFalse(self.trainer.running)

    def test_toggle_enables(self):
        """Test toggling enables the trainer."""
        self.trainer._toggle()
        self.assertTrue(self.trainer.running)

    def test_toggle_disables(self):
        """Test toggling twice disables the trainer."""
        self.trainer._toggle()
        self.trainer._toggle()
        self.assertFalse(self.trainer.running)

    @patch("src.trainer.pyautogui.click")
    def test_auto_click_when_disabled(self, mock_click):
        """Test that auto_click does nothing when trainer is off."""
        self.trainer.auto_click(100, 200)
        mock_click.assert_not_called()

    @patch("src.trainer.pyautogui.click")
    def test_auto_click_when_enabled(self, mock_click):
        """Test that auto_click works when trainer is on."""
        self.trainer._toggle()
        self.trainer.auto_click(100, 200)
        mock_click.assert_called_once_with(100, 200)

    def test_stop(self):
        """Test that stop disables trainer."""
        self.trainer._toggle()
        self.trainer.stop()
        self.assertFalse(self.trainer.running)

if __name__ == "__main__":
    unittest.main()