   M S B A M L   `   `   `  ����P  LRun Multiple Apps GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Run_Multiple_Apps_GUIRun_Multiple_Apps_GUI  5   	   &     Run_Multiple_Apps_GUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Run_Multiple_Apps_GUI     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowState$ Normal=�65    � 
ResizeMode$ NoResize=�6J   .��5	      � .+�5
   
   �� $
��Left=�6   $��
134,10,0,0q�6/   $&�� Run and Create Multiple Apps GUI��6C   $
��Wrap=�6k   $	��Top=�6   $��52��6�   $	��550��6�   $��36(�6�   �� 5   
   -   5        $	��Run��5      $��Center=�6   $��	0,342,0,0q�6<   $	��Top=�6O   $��66��6g   $	��126��6s   $��36(�6   6�   �� 5   
   -   5         ��Name$ App_Select_Button��5      $��Center=�6,   $��0,95,0,0q�6I   $	��Top=�6[   $��52��6�   $	��298��6�   .��5      ��  �� TextAlignment$ Center=�6   $
��Wrap=�6/   $��14(�6C   �� 6R   $4�.Select the apps you would like to run together��6V   �� 6�   �� 6�   $�Afterwards click run��6�   6�   5      �� 5   
   -   5         ��Name$ SelectedText��5      " �� VerticalScrollBarVisibility$
 Auto=�6(    �� 
IsReadOnly$
 True��6K   $��Center=�6]   $��	0,185,0,0q�6z    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��298��6�   $	��140��6�   �� 5   
   $
��Left=�6   $��251,163,0,0q�6/   $��Currently Selected:��6D   $
��Wrap=�6_   $	��Top=�6s   $��17��6�   $	��108��6�   �� 5   
   -   5        $ Select_Path_Button��5      $
��Left=�6-   $��
598,95,0,0q�6H   $	��Top=�6\   $��62��6t   $	��163��6�   .��5      �� $ Center=�6   $
��Wrap=�6/   $��14(�6C   $��64��6Q   $	��163��6]   �� 6j   $�Please select where��6n   �� 6�   �� 6�   $5�/you want the file runner to save and write name��6�   �� 6�   �� 6�   6�   5      �� 5   
   $
��Left=�6   $��598,185,0,0q�6/   $��Current Path:��6D   $
��Wrap=�6Y   $	��Top=�6m   $��17��6�   $��73��6�   �� 5   
   -   5        $ Current_Path��5      $
 True��6(   $
��Left=�6:   $��598,217,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��173��6�   $��37��6�   �� 5   
   -   5        $ Clear_Button��5      $
��Left=�6'   $��	10,95,0,0q�6B   $	��Top=�6U   $��52��6m   $	��223��6y   $��20(�6�   .��5      �� $
��Wrap=�6   $ Center=�6,   	 J� RenderTransformOrigin$	 0.504,0.712&�6C   $��31��6g   �� 6t   $�Clear Selected Apps��6x   �� 6�   �� 6�   6�   5      5      5      