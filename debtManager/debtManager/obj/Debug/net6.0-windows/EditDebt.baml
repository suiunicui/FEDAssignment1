   M S B A M L   `   `   `  ����F  BdebtManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:debtManagerdebtManager  5   	       debtManager.EditDebt   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:debtManager     5   	     � Title$  EditDebt��5   	   $	��450��6   $	��600��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��4* �6    � ColumnDefinitions 5   
   �� 5      $	��15* �6   �� 5      $	��10* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DebitListBox��5      $��1��5      $��0��5      $��50,10,50,20q�5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5         
IsReadOnly$
 True��5         AutoGenerateColumns$ False��5      ��5      ��  �� Path$ CurrentDebt.DebitList�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 1* 6L   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *Date+6L     5      $ Payment��6%   $	 1* 6R   
 66   �� *	Payment+6R   5      �� 5   
   -   5         ��Name$ PaymentValue��5      $��1��5       $��1��5!      $	��Top=�5"      $
��Left=�5#      $��	10,10,0,0q�5$      $	��175��5%      $��31��5'      $��20(�5(      ��5&      �� $ NewDebitPayment.Payment�5(      �� 5)   
   -   5         ��Name$ AddValue��5)      $��1��5*      $��1��5+      $��	Add Value��5,      $	��Top=�5-      $
��Left=�5.      $��	10,68,0,0q�5/       �� 	ClickMode$ Release=�50      $	��175��52   &   $��50��62   ��51      �� $ AddValueCommand�52   2   �� 53   
   $��Payment history��6   $��0��6+      
TitleStyle#��[  68   $	��Top=�6\   $��50,20,60,347q�6t   $��2��6�   �� 54   
   $��Add payment��6   $��1��6'   $��0��67   #��[  6D   $	��Top=�6h   $��10,20,60,347q�6�   $��2��6�   55      56      