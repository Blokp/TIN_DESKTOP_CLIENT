   M S B A M L   `   `   `  ����E  ADocsClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DocsClient
DocsClient  5   	       DocsClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:DocsClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��31* �6   �� 5      $
��167* �6   .+�5   
   �� -   5        $��Connect��5      $
��Left=�5      $��
162,45,0,0q�5      $	��Top=�5      $��56��5       J� RenderTransformOrigin$ 0.581,1.061&�5   '   $��1��6K   $��20��6[   �� 5   
   -   5        $��StatusLabel��5   f   $
��Info��6   $
��Left=�6   $��
314,42,0,0q�6:   $	��Top=�6N   $ 0.003,0.919&�6y   $��1��6�   $��26��6�   $	��117��6�   �� 5   
   -   5        $��IPField��5   �   $
��Left=�6   $��23��6-   $��	20,45,0,0q�69    �� TextWrapping$
 Wrap=�6L   $��	127.0.0.1��6`   $	��Top=�6q   $	��144��6�   $��2��6�   6�   �� 5   
   -   5        $��ToSend��5   �   $
��Left=�6   $��36��6-   $��	20,93,0,0q�69   $
 Wrap=�6L   $�� ��6`   $	��Top=�6j   $	��173��6�   $��2��6�   6�   �� 5   
   -   5         ��Name$ 	PortField��5   �   $
��Left=�6   $��23��6-   $��	70,45,0,0q�69   $
 Wrap=�6L   $��11111��6`   $	��Top=�6m   $��66��6�   $��1��6�   6�   �� 5   
   -   5        $
��Stop��5      $
��Left=�5      $��
223,45,0,0q�5      $	��Top=�5      $��56��5      $ 0.581,1.061&�5       $��1��6D   $��20��6T   �� 5   
   -   5        $��	ToReceive��5   �   $��1��6   $
��Left=�6"   $	��274��6=   $��
118,93,0,0q�6J   $
 Wrap=�6^   $��TextBox��6r   $	��Top=�6�   $	��524��6�   6�   �� 5   
   -   5        $
��Send��5      $
��Left=�5       $��
46,195,0,0q�5!      $	��Top=�5"      $��54��5#      $ 0.581,1.061&�5$       $��1��6D   $��20��6T   5%      5&      