import os
import logging
from openvino.inference_engine import IENetwork, IEPlugin
import copy
import uuid
import cv2
import numpy as np

class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y 

class Margin:
    def __init__(self,w,h):
        self.w = w
        self.h = h

class Location:
    """
    Representation of a location of a frame

    Attributes
    ----------
    Point (top left corner (X/Y))
    Margin ( offset from X/Y in width:w and height:h)
    """

    def __init__(self, x, y, w, h):
        self.beginPoint = Point(x,y)
        self.margin = Margin(w,h)

    def get_centroid(self):
        """
        Calculates centroid
        :return: Coordinate tuple
        """
        return Point((self.beginPoint.x + self.margin.w)/2, (self.beginPoint.y + self.margin.h)/2)
    
    def get_surface(self):
        """
        Calculates surface in pixels
        """
        return (self.margin.w * self.margin.h)

    def get_boundingBox(multiplier):
        """
        Calculates a (multiplier)times boundingbox area of location from midpoint
        """
        return Margin((self.margin.w/2)*multiplier,(self.margin.h/2)*multiplier)

    def Merge(self,location):
        """
        TODO: IMPLEMENT
        marges 2 locations into one (picking average location)
        """ 

    def __str__(self):
        return 'Location(x={}, y={}, w_offset={}, h_offset={})'.format(self.beginPoint.x, self.beginPoint.y, self.margin.w, self.margin.h)

    def __repr__(self):
        return self.__str__()
    
class Human:
    def __init__(self, face, emotion,uniqueID):
        self.face = face
        self.emotion = emotion 
        self.uniqueID = uniqueID
    def __str__(self):
        return self.face

    def __repr__(self):
        return self.__str__()
    
    def visualise(self, frame):
        draw_bounding_box(self.face,frame)
        cv2.putText(frame, self.emotion, (self.face.location.beginPoint.x + 10 ,self.face.location.beginPoint.y+ self.face.location.margin.h - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.65,(0,0,0),2)
        return frame

def draw_bounding_box(detection_output, frame, color=(50, 50, 50), thickness=2):
    if detection_output is not None:
        min_x = detection_output.location.beginPoint.x
        min_y = detection_output.location.beginPoint.y

        cv2.rectangle(
            frame,
            (min_x, min_y),
            (min_x + detection_output.location.margin.w, min_y + detection_output.location.margin.h),
            color,
            thickness
        )