using Almacen.domain.DTOS;
using Almacen.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Almacen.api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductoController : Controller
	{
		private readonly AlmacenContext _context;

		public ProductoController(AlmacenContext context)
		{
			_context = context;
		}
		[HttpGet(Name = "GetProducto")]
		public IActionResult GetProducto()
		{
			try
			{
				var productos = _context.Productos.Select(p => new ProductoDTO
				{
					Id = p.Id,
					Precio = p.Precio,
					Descripcion = p.Descripcion,
					Marca = p.Marca,
					Stock = p.Stock,
					Activo = p.Activo,

				}).ToList();
				return Ok(productos);
			}
			catch (Exception)
			{

				return StatusCode(500, "Ocurrió un error inesperado al obtener los Productos.");
			}
		}
		[HttpPost(Name = "PostProductos")]
		public async Task<IActionResult> PostProductos(ProductoDTO productoDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var newProductos = new Producto
				{
					Nombre = productoDTO.Nombre,
					Descripcion = productoDTO.Descripcion,
					Marca = productoDTO.Marca,
					Stock = productoDTO.Stock,
					Activo = productoDTO.Activo,
				};
				_context.Productos.Add(newProductos);
				await _context.SaveChangesAsync();
				return Ok(new { message = "El producto fue agregado exitosamente", Data = newProductos });

			}
			catch (Exception)
			{

				return StatusCode(500, "Ocurrió un error inesperado al crear el producto.");
			}
		}

		[HttpPut("{id}", Name = "PutProductos")]
		public async Task<IActionResult> PutProducto(int id,PutProductoDTO producto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var updateProducto = await _context.Productos.FindAsync(id);
				if (updateProducto == null)
				{

				return NotFound(); 
				}

				updateProducto.Nombre = producto.Nombre;
				updateProducto.Descripcion = producto.Descripcion;
				updateProducto.Marca = producto.Marca;
				updateProducto.Precio= producto.Precio;
				updateProducto.Activo = producto.Activo;

				_context.Productos.Update(updateProducto);
				await _context.SaveChangesAsync();

				return Ok(new { message = "La actualizacino fue realizada con exito", Data = updateProducto });
				
			}
			catch (Exception)
			{

				return StatusCode(500, "Ocurrió un error inesperado al actualizar el producto.");
			}
		}

		[HttpDelete("{id}", Name ="DeleteProductos")]
		public async Task<IActionResult> DeleteProductos(int id)
		{
			try
			{
				var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
				if (producto == null)
				{

				return NotFound(); 
				}

				_context.Productos.Remove(producto);
				await _context.SaveChangesAsync();
				return Ok(new {message = "El producto fue eliminado con exito"});
			}
			catch (Exception)
			{

				return StatusCode(500, "Ocurrió un error inesperado al actualizar el producto.");
			}
		}
	}
}
