/* csvorbis
 * Copyright (C) 2000 ymnk, JCraft,Inc.
 *  
 * Written by: 2000 ymnk<ymnk@jcraft.com>
 * Ported to C# from JOrbis by: Mark Crichton <crichton@gimp.org> 
 *   
 * Thanks go to the JOrbis team, for licencing the code under the
 * LGPL, making my job a lot easier.
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Library General Public License
 * as published by the Free Software Foundation; either version 2 of
 * the License, or (at your option) any later version.
   
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Library General Public License for more details.
 * 
 * You should have received a copy of the GNU Library General Public
 * License along with this program; if not, write to the Free Software
 * Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
 */


using System;
using System.Runtime.InteropServices;
using csogg;

namespace csvorbis 
{
	/*
	  function: LSP (also called LSF) conversion routines

	  The LSP generation code is taken (with minimal modification) from
	  "On the Computation of the LSP Frequencies" by Joseph Rothweiler
	  <rothwlr@altavista.net>, available at:
  
	  http://www2.xtdl.com/~rothwlr/lsfpaper/lsfpage.html 
	 ********************************************************************/

	class Lsp
	{

		static float M_PI=(float)(3.1415926539);

		internal static void lsp_to_curve(float[] curve,
			int[] map, int n, int ln,
			float[] lsp, int m,
			float amp, float ampoffset)
		{
			int i;
			float wdel=M_PI/ln;

			for(i=0;i<m;i++)
				lsp[i]=2.0f * (float)Math.Cos(lsp[i]);

			i=0;
			while(i<n)
			{
				int j,k=map[i];
				float p=0.5f;
				float q=0.5f;
				float w=2.0f * (float)Math.Cos(wdel*k);

				for(j=1; j < m; j += 2)
				{
					q *= w - lsp[j-1];
					p *= w - lsp[j];
				}

				if(j == m)
				{
					/* odd order filter; slightly assymetric */
					/* the last coefficient */
					q*=w-lsp[j-1];
					p*=p*(4.0f-w*w);
					q*=q;
				}
				else
				{
					/* even order filter; still symmetric */
					q*=q*(2.0f+w);
					p*=p*(2.0f-w);
				}

				q = (float)(Math.Exp(amp/Math.Sqrt(p+q)-ampoffset))
					    * 0.11512925f;
				curve[i] *= q;
				while(map[++i] == k) curve[i] *= q;
			}
		}
	}
}
