   M S B A M L   `   `   `  ����F  BdebtManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:debtManagerdebtManager  5   	       debtManager.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:debtManager     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5
   	     � Title$  DebtBook��5	   	   $	��450��6   $	��800��6'   !  Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5   	    � 
ResizeMode$ NoResize=�5   	    � Icon$ trayIcon.png��5   	    � 	Resources 5         
labelStyle �� Property �� Value  boxStyle��%�   &	        &	 ?     �� 5   
   .�5      ��  � ��$	 8pt(�61   5      �� 5   
   .�5      ��  � ��$	 8pt(�61   �� 5       � ��
 �   �63   �� 5       � ��
 �����63   5      5      .��5      ]�   backgroundColor#��[ 6   .+�5   
   o� -   5        $
��menu��5   $   $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� $��	Load File��6    m� Command 6/   �� *LoadFileCommand+m� 5      $��Save To File��6    62   �� *SaveFileCommand+m� 5      $
��Exit��6    6*   �� *ExitCommand+5      m� 5      $
��Debt��6   .@�5       m� $	��Add��6    6(   �� *AddDebtCommand+m� 5!      $��Delete��6    6+   �� *DeleteDebtCommand+5"      5#      �� 5%   
   $��Bottom=�6     toolBarColor#��[ 6,   $
��auto��6W   $��12(�6e   .@�5&      �� $��Debtor Count:��6   �� 5'      ��6   ��  �� Path$ Debts.Count��� 5(      -   5        $��sbiDateTime��5(      $��Right=�6/   5)      5*      � 5+   
   #��[ 6   	 � RowDefinitions	 5,      �� 5-      $	��60* �6    �� 5.      $	��60* �6    �� 5/      $
��270* �6    
 � ColumnDefinitions
 51      �� 52      $��1* �6#   �� 53      $��1* �6#   .+�55      &   System.Windows.Controls.DataGrid  -   5        $��ListBox1��55      $ �� IsSynchronizedWithCurrentItem$
 TrueY�59         
IsReadOnly$
 True��5:      $��1��5;      $��0��6   $��50,10,60,100q�6.   $��2��6D      AutoGenerateColumns$ False��5<      ��56      �� $ Debts� �� SelectedItem 57      �� $ CurrentDebt� �� SelectedIndex 58      �� $ CurrentIndex�   Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ Amount��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Amount+6T     5?      $
 Name��6)   $ 2* 6R    67   �� *Debtor+6R   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5A      +  %Microsoft.Xaml.Behaviors.EventTrigger  5B         	EventName$ MouseDoubleClick��6%   *	  $Microsoft.Xaml.Behaviors.TriggerBase 	  Actions. 5C      -
  'Prism.Interactivity.InvokeCommandAction
   
  Command 64   �� *EditCommand+5D      5F      �� 5G      $��1��6   $��1��6%   $��Add Debt��62   $��100,10,100,0q�6E   ��6[   �� *AddDebtCommand+�� 5H      $��Debtors��6     
TitleStyle#��[ 6'   $��50, 10, 60, 0q�6K   5K      5M      5N      