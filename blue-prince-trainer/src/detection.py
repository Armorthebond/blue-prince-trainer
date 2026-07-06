"""Screen detection utilities for Blue Prince game elements."""

import cv2
import numpy as np
import pyautogui
import logging

logger = logging.getLogger(__name__)

class ScreenDetector:
    """Detects game elements on screen using template matching."""

    def __init__(self, template_path: str = None):
        self.template = None
        if template_path:
            self.load_template(template_path)

    def load_template(self, path: str):
        """Load a template image for matching."""
        self.template = cv2.imread(path, cv2.IMREAD_GRAYSCALE)
        if self.template is None:
            raise FileNotFoundError(f"Template not found: {path}")
        logger.info(f"Loaded template: {path}")

    def find_element(self, threshold: float = 0.8) -> tuple:
        """Find element on screen. Returns (x, y) center or None."""
        if self.template is None:
            logger.warning("No template loaded")
            return None

        screenshot = pyautogui.screenshot()
        screen = cv2.cvtColor(np.array(screenshot), cv2.COLOR_RGB2GRAY)
        result = cv2.matchTemplate(screen, self.template, cv2.TM_CCOEFF_NORMED)
        _, max_val, _, max_loc = cv2.minMaxLoc(result)

        if max_val >= threshold:
            h, w = self.template.shape
            center_x = max_loc[0] + w // 2
            center_y = max_loc[1] + h // 2
            logger.debug(f"Element found at ({center_x}, {center_y})")
            return (center_x, center_y)

        logger.debug("Element not found")
        return None