   M S B A M L   `   `   `  ����F  BinvoiceWPF2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:invoiceWPF2.UIinvoiceWPF2.UI  5   	       invoiceWPF2.UI.products   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:invoiceWPF2.UI     5   	     � Title$  products��5   	   $	��450��6   $	��800��6'   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgvProducts��5
      $��299,19,24,151q�6(   6R   �� 5   
   $��Items:��6   $
��Left=�6!   $��	26,69,0,0q�6<   $	��Top=�6O    J� RenderTransformOrigin$ 0.505,0.618&�6g   $��98��6�   $��14(�6�   �� 5   
   -   5         ��Name$ txtPID��5      $
��Left=�6"   $��
129,74,0,0q�6=    �� TextWrapping$
 Wrap=�6Q   $	��Top=�6e   $	��120��6}    �� 
IsReadOnly$
 True��6�   �� 5   
   $��Amount:��6   $
��Left=�6"   $��
26,176,0,0q�6=   $	��Top=�6Q   $ 0.505,0.618&�6i   $��98��6�   $��14(�6�   �� 5   
   -   5        $ 	txtAmount��5      $
��Left=�6%   $��129,181,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��120��6�   �� 5   
   $��Description:��6   $
��Left=�6'   $��
26,137,0,0q�6B   $	��Top=�6V   $ 0.505,0.618&�6n   $��98��6�   $��14(�6�   �� 5   
   -   5        $ txtPdescription��5      $
��Left=�6+   $��129,142,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $	��120��6�   �� 5   
   $��Price:��6   $
��Left=�6!   $��
26,213,0,0q�6<   $	��Top=�6P   $ 0.505,0.618&�6h   $��98��6�   $��14(�6�   �� 5   
   -   5        $ txtPrice��5      $
��Left=�6$   $��129,218,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5   
   -   5         ��Name$ addProducts��5      $	��Add��6&   $
��Left=�64   $��189,326,0,0q�6O   $	��Top=�6d   ���	#FF44AD30$��14(�6�   $��54��6�   6�   �� 5   
   -   5        $ updateProducts��5      $��Update��6)   $
��Left=�6:   $��325,326,0,0q�6U   $	��Top=�6j   ���	#FF87C7A8$��14(�6�   $��59��6�   6�   �� 5   
   -   5        $ deleteProducts��5      $��Delete��6)   $
��Left=�6:   $��457,326,0,0q�6U   $	��Top=�6j   ���	#FFB93F33$��14(�6�   $��60��6�   6�   �� 5   
   -	   5        $ cancelProducts��5      $��Cancel��6)   $
��Left=�6:   $��589,326,0,0q�6U   $	��Top=�6j   ���	#FFF1E9E9$��14(�6�   $��58��6�   6�   5      5      