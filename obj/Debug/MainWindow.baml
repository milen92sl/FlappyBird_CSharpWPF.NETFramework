   M S B A M L   `   `   `  ����D  @CrazyBird, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CrazyBird	CrazyBird  5   	       CrazyBird.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CrazyBird     5   	   -   5          � Title$(  "Flappy Bird Game in WPF by Moo ICT��5   	   $	��490��64   $	��525��6A    +� FocusedElement 6M   ��  �� ElementName$ myCanvas��.��5
      �� -   5        $��MyCanvas��5
      |�. 
����ح�.+�5   
   �� $	��145��6   $	��207��6   $��images/clouds.png��6)    �� Left$ 20��6D   
 �� Top$ 10��6U   
 � Tag$ clouds��6e   �� 5   
   $	��145��6   $	��207��6   $��images/clouds2.png��6)   $	 300��6E   $ 96��6W   $ clouds��6g   �� 5   
   $	��389��6   $��75��6   $��images/pipeBottom.png��6(   $	 107��6H   $	 283��6Z   $
 obs1��6k   �� 5   
   $	��387��6   $��66��6   $��images/pipeTop.png��6(   $	 107��6D   $
 -254��6V   $
 obs1��6h   �� 5   
   $	��389��6   $��75��6   $��images/pipeBottom.png��6(   $	 280��6H   $	 327��6Z   $
 obs2��6k   �� 5   
   $	��387��6   $��66��6   $��images/pipeTop.png��6(   $	 280��6D   $
 -182��6V   $
 obs2��6h   �� 5   
   $	��389��6   $��75��6   $��images/pipeBottom.png��6(   $	 451��6H   $	 224��6Z   $
 obs3��6k   �� 5   
   $	��387��6   $��66��6   $��images/pipeTop.png��6(   $	 451��6D   $
 -291��6V   $
 obs3��6h   �� 5   
   -   5        $��	scoreText��5      $��20(�6!   $��Score: 0��6/   �� 5   
   -   5        $��
flappyBird��5      $
��Fill=�6   $��37��61   $��50��6=   $��images/bird.png��6H   $ 20��6a   $	 174��6r   5      5      