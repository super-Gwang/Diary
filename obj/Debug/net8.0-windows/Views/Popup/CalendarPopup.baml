   M S B A M L   `   `   `  ����C  ?DiaryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:DiaryApp.Views.PopupDiaryApp.Views.Popup  5   	   (    "DiaryApp.Views.Popup.CalendarPopup   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:DiaryApp.Views.Popup     5   	   -   5          �Name$  MainWin��5   	    � Title$ CalendarPopup��5	   	   $	��350��6   $	��380��6,   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��Center=�6   $	��Top=�69   $��0,10,0,0q�6Q   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� $	��◀��6   $��30��6%   
������ $��0q�6r   ��60   �� *PreviousMonthCommand+6r   �� 5      -   5         ��Name$ MonthYearText��5      $��20(�6O   $
��Bold"�6]    �� TextAlignment$ Center=�6o   ��63   �� *
SelectDate+6o   �� 5      $	��▶��6   $��30��6%   
������ $��0q�6n   ��60   �� *NextMonthCommand+6n   5      5      � 5   
   $��1��6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5       �� 5!      $
��Auto �6#   �� 5"      $
��Auto �6#   �� 5#      $
��Auto �6#   �� 5$      $
��Auto �6#   �� 5%      $
��Auto �6#   �� 5&      $
��Auto �6#   �� 5'      $
��Auto �6#   .+�5*      �� ��6   �� *
DayButtons+��5+      �� 5,      .R�5-      A�  A� Rows$ 5��6&    A� Columns$ 7��6/   5.      ��50      �� 51      .R�52      *   $DiaryApp.Views.Popup.CustomDayButton  	 � DataContext	 53      �� 54      56      57      58      59      