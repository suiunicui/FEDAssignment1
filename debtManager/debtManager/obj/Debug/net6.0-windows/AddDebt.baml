   M S B A M L   `   `   `  ����F  BdebtManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:debtManagerdebtManager  5   	       debtManager.AddDebt   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:debtManager     5   	     � Title$  AddDebt��5   	   $	��225��5	   	   $	��200��6    � 
ResizeMode$ NoResize=�5
   	    � ShowInTaskbar$ False��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $	��40* �6   �� 5      $	��20* �6   �� 5      $	��40* �6   �� 5      $	��20* �6   �� 5      $	��40* �6   �� 5      $	��50* �6   .+�5   
   �� $��
Add Debtor��6   $��0��5      $��0��6$   $��2��61      
TitleStyle#��[  5      �� 5   
   -   5         ��Name$ 
debtorName��5      $��0��5      $��2��6"   $��2��6/   $��
30,0,30,20q�6C   $��1��5      ��5      ��  �� Path$ CurrentDebt.Debtor�5      �� 5    
   $
��Name��6   $��0��5!      $��1��6$   $��2��61   $��10,0,-10,40q�6E   $��2��6Z   �� 5"   
   -   5        $ initialValue��5"      $��0��5#      $��4��6"   $��2��6/   $��
30,0,30,20q�6C   $��2��5%      ��5$      �� $ CurrentDebt.Amount�5%      �� 5&   
   $��Initial Amount��6   $��0��5'      $��3��6$   $��2��61   $��
10,0,-10,0q�6E   �� 5(   
   -   5         ��Name$ 
saveDebtor��5(      $
��Save��5)      $��0��6    $��5��60   $��1��6=   $��10,10,10,10q�6Q   ��5*      �� $ SaveCommand�66   �� 5+   
   -   5        $ 	cancelAdd��5+      $��Cancel��5,      $��1��6"   $��5��62   $��1��6?   $��10,10,10,10q�6S    �� IsCancel$
 True��6h   5.      5/      