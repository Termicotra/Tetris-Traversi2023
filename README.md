# Tetris - Traversi 2023

Proyecto: implementación de un juego Tetris creada como trabajo/práctica del curso Lenguaje de Programación II 2023.

Estado: (Abandonado)

Lenguaje principal
- C# (100%)

Descripción
- Este repositorio contiene el código fuente de una implementación de Tetris en C#. El objetivo es ofrecer una versión funcional del clásico juego de bloques (tetriminos), con las mecánicas básicas: generación de piezas, rotación, caída, línea completa y puntuación.

Características principales (esperadas)
- Mecánica clásica de Tetris (caída de piezas, rotación, choque, fijación).
- Detección y eliminación de líneas completas.
- Sistema de puntuación básico.
- Control de velocidad / niveles.
- Interfaz simple.

Requisitos
- .NET SDK 6.0+ 
- Un editor de C# (Visual Studio / Visual Studio Code / Rider) según corresponda

Controles 
- Flecha izquierda / A: mover pieza a la izquierda
- Flecha derecha / D: mover pieza a la derecha
- Flecha abajo / S: bajar más rápido
- Barra espaciadora / W: soltar pieza (hard drop)
- Flecha Arriba / rotar pieza

Buenas prácticas y notas para mantenedores
- Mantener la lógica del juego (gestión de tablero, movimiento, rotación, colisiones y eliminación de líneas) separada de la capa de presentación (renderizado/interfaz) para facilitar tests y mantenimiento.
- Añadir tests unitarios para la lógica crítica: colisión, rotación, cálculo de líneas y puntuación.

Cómo contribuir
1. Haz fork del repositorio.
2. Crea una rama con la funcionalidad o corrección: `git checkout -b feat/nueva-caracteristica`
3. Haz commits claros y descriptivos.
4. Envía un pull request describiendo los cambios y su motivación.
5. Usa issues para discutir nuevas características o bugs antes de empezar implementaciones grandes.

Posibles mejoras
- Añadir sistema de niveles y aumentando la velocidad.
- Implementar hold (pieza reservada).
- Guardado de récords / tabla de puntuaciones.
- Soporte para entrada por gamepad.
- Mejoras visuales (sprites, efectos, animaciones).
