   M S B A M L   `   `   `  ����E  Acrypto_wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:crypto_wpf.Windowscrypto_wpf.Windows  5   	   =#clr-namespace:crypto_wpf.ViewModelscrypto_wpf.ViewModels  68   #    crypto_wpf.Windows.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:crypto_wpf.Windows     5   	   9	viewModel#clr-namespace:crypto_wpf.ViewModels     68   -   5          � Title$  
MainWindow��5   	   $	��465��6   $	��815��6)    � 
ResizeMode$ CanMinimize=�5	   	      WindowStyle#���   6"   .��5
      � $	��800��6   $	��435��6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ currency_dataGrid��5      $��0,43,305,217q�6H   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6^      
IsReadOnly$
 True��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 150 6�      RowHeaderWidth$ 0Q�6�   $��Cascadia Code)�6�   $��14(�6�   $��Right=�6  $	��485��65    DataGridStyle#���  6A  
�������6i  �� 5   
   $��List of currencies:��6   $
��Left=�6.   $��	10,14,0,0q�6I   $	��Top=�6\   $	��195��6t   $��Cascadia Code)�6�   $��16(�6�     
LabelStyle#���  6�   �� 5   
   $��Top 10 currencies:��6   $
��Left=�6-   $��
10,222,0,0q�6H   $	��Top=�6\   $��Cascadia Code)�6t   $��16(�6�   $	��171��6�   #���  6�     5   
   -   5        $ topCurrency_dataGrid��5      $��10,250,305,10q�6K   $
 TrueY�6b   $
 True��6�   $	 150 6�   $ 0Q�6�   $��Cascadia Code)�6�   $��14(�6�   $��Right=�6   $	��485��6<  #���  6H  �� 5   
   $��Search for currency:��6   $
��Left=�6/   $��
513,14,0,0q�6J   $	��Top=�6^   $��Cascadia Code)�6v   $��16(�6�   #���  6�   �� 5   
   -   5         ��Name$ search_TextBox��5      $
��Left=�6*   $��
513,43,0,0q�6E    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $	��277��6�   $��Cascadia Code)�6�   $��16(�6�   $��20��6�     TextBoxStyle#���  6�   �� 5   
   -   5        	 ��Name$	 search_Button��5      $��Search��6(   $
��Left=�69   $��
730,73,0,0q�6T   $	��Top=�6h   $��Cascadia Code)�6�   $��16(�6�   $��60��6�     ButtonStyle#���  6�   �� 5   
   -   5        $	 changeStyle_Button��5      $��Change current mode��6-   $
��Left=�6K   $��513,250,0,0q�6f   $	��Top=�6{   $��Cascadia Code)�6�   $��16(�6�   $	��197��6�   $��28��6�   #���  6�   �� 5   
   -   5        $��Go to converter��5      $
��Left=�6+   $��513,295,0,0q�6F   $	��Top=�6[   $��Cascadia Code)�6s   $��16(�6�   $	��197��6�   $��28��6�   #���  6�   5      5      