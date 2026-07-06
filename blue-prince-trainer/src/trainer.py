"""Core trainer logic for Blue Prince game automation."""

import time
import pyautogui
import keyboard
import logging

logger = logging.getLogger(__name__)

class BluePrinceTrainer:
    """Main trainer class for automating game actions."""

    def __init__(self, hotkey: str = "ctrl+shift+x"):
        self.hotkey = hotkey
        self.running = False
        self._setup_hotkey()

    def _setup_hotkey(self):
        """Register the global hotkey to toggle automation."""
        keyboard.add_hotkey(self.hotkey, self._toggle)

    def _toggle(self):
        """Toggle the trainer on/off."""
        self.running = not self.running
        status = "enabled" if self.running else "disabled"
        logger.info(f"Trainer {status}")

    def auto_click(self, x: int, y: int, interval: float = 0.1):
        """Automatically click at given coordinates while running."""
        if not self.running:
            return
        pyautogui.click(x, y)
        time.sleep(interval)

    def spam_key(self, key: str, count: int = 10, delay: float = 0.05):
        """Spam a keyboard key when trainer is active."""
        if not self.running:
            return
        for _ in range(count):
            if not self.running:
                break
            keyboard.press_and_release(key)
            time.sleep(delay)

    def stop(self):
        """Cleanly stop the trainer."""
        self.running = False
        keyboard.remove_hotkey(self.hotkey)
        logger.info("Trainer stopped")